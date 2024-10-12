using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Input;
using OSGames.BoardGame.Interactables;
using UnityEngine.InputSystem;

namespace OSGames.BoardGame.Player {

    [RequireComponent(typeof(PlayerModel))]
    [RequireComponent(typeof(PlayerCommandFactory))]
    [RequireComponent(typeof(PlayerActionFactory))]
    // [RequireComponent(typeof(PhaseEventSubscriber))]
    [RequireComponent(typeof(PlayerEventPublisher))]
    [Icon("Packages/com.osgames.boardgame/Assets/Icons/osgames_logo.png")]
    public class PlayerController : Controller, ISubscriber<InputType>, ISubscriber<InteractableEvent>, IFactory<PlayerActionProduct,PlayerActionCommand>, IScheduler
    {

        // Scheduler to execute player actions
        Scheduler m_Scheduler;

        // Factory to generate player commands for the scheduler
        protected PlayerCommandFactory m_CommandFactory;
        protected PlayerActionFactory m_MenuActionFactory;

        PlayerModel m_PlayerModel;
        public PlayerModel PlayerModel { get { return m_PlayerModel;}}

        PlayerMenuModel m_PlayerMenu;
        public PlayerMenuModel PlayerMenu { get { return m_PlayerMenu; } }

        IPublisher<InputType> m_InputPublisher;
        Subscriber<InteractableEvent> m_InteractableEventSubscriber;

        
        // SubscriberBehaviour<PhaseEvent> m_PhaseEventSubscriber;
        PublisherBehaviour<PlayerEvent> m_PlayerEventPublisher;
        public PublisherBehaviour<PlayerEvent> publisher {
            get {return m_PlayerEventPublisher; }
        }

        public enum State {
            ActiveControls,
            InactiveControls,
            Menu,

        }
        State m_State = State.InactiveControls;
        public State state {
            get { return m_State; }
            set { m_State = value; }
        } 

        protected RoomController m_CurrentRoom;
        public RoomController CurrentRoom {
            get { return m_CurrentRoom; }
            set { m_CurrentRoom = value; }
        }

        protected virtual void Awake(){
            m_Scheduler = new Scheduler();
            m_CommandFactory = GetComponent<PlayerCommandFactory>();
            m_MenuActionFactory = GetComponent<PlayerActionFactory>();

            m_PlayerModel = GetComponent<PlayerModel>();

            m_InputPublisher = GetComponent<IPublisher<InputType>>();

            m_PlayerMenu = GetComponentInChildren<PlayerMenuModel>();

            m_InteractableEventSubscriber = new Subscriber<InteractableEvent>();

            // m_PhaseEventSubscriber = GetComponent<SubscriberBehaviour<PhaseEvent>>();

            m_PlayerEventPublisher = GetComponent<PublisherBehaviour<PlayerEvent>>();
        }

        protected virtual void Start(){
            // player input event subscriber
            SubscribeTo(m_InputPublisher);
            
            // interactable event subscriber
            m_InteractableEventSubscriber.PublisherAction += OnInteractableEvent;
            // m_PhaseEventSubscriber.PublisherAction += OnPhaseEvent;
        }

        void OnDestroy(){
            // m_RoomActionSubscriber.PublisherAction -= OnRoomAction;
        }


        protected virtual void OnInput(InputType type){
            bool validMenuCommand = (type == InputType.ToggleMenu || type == InputType.Back) && m_State == State.Menu;
            bool validStandardCommand = type != InputType.Confirm && m_State == State.ActiveControls;
            bool validConfirmCommand = type == InputType.Confirm && m_State == State.ActiveControls && m_PlayerModel.GetHasTarget();
            if (validMenuCommand || validStandardCommand || validConfirmCommand)
            {
                PlayerCommandProduct product = new PlayerCommandProduct(this, type);
                Command cmd = m_CommandFactory.Make(product);
                ExecuteCommand(cmd);
            }
        }

        public virtual void SubscribeTo(IPublisher<InputType> publisher){
            publisher.AddListener(OnInput);
        }

        public virtual void UnsubscribeFrom(IPublisher<InputType> publisher){
            publisher.RemoveListener(OnInput);
        }

        public virtual PlayerActionCommand Make(PlayerActionProduct product)
        {
            return m_MenuActionFactory.Make(product);
        }

        public void ExecuteCommand(ICommand cmd)
        {
            m_Scheduler.ExecuteCommand(cmd);
        }

        public ICommand UndoCommand()
        {
            return m_Scheduler.UndoCommand();
        }

        public void SubscribeTo(IPublisher<InteractableEvent> publisher)
        {
            m_InteractableEventSubscriber.SubscribeTo(publisher);
        }

        public void UnsubscribeFrom(IPublisher<InteractableEvent> publisher)
        {
            m_InteractableEventSubscriber.Unsubscribe();
        }

        protected virtual void OnInteractableEvent(InteractableEvent interactableEvent){
            Debug.Log("Recieved event from interactable.");
            if (interactableEvent.type == InteractableEventType.InteractFinish){
                Command cmd = new PlayerFinishInteractionCommand(this);
                ExecuteCommand(cmd);
            }
        }

        public virtual void Damage(Damage damage){
            Debug.Log($"Player was hit with: {damage}");
        }

        public virtual void StartTurn(){
            
        }

        // protected virtual void OnPhaseEvent(PhaseEvent phaseEvent){
        //     Command cmd = new ProcessPlayerPhaseEventCommand(this,phaseEvent);
        //     cmd.Execute();
        // }
    }
}