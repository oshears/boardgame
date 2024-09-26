using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Input;

namespace OSGames.BoardGame.Player {

    [RequireComponent(typeof(PlayerModel))]
    [RequireComponent(typeof(PlayerCommandFactory))]
    [RequireComponent(typeof(PlayerActionFactory))]
    public class PlayerController : Controller, ISubscriber<InputType>, IFactory<PlayerActionProduct,PlayerActionCommand>, IScheduler
    {

        // subscriber to actions received from game menu / room
        // public Subscriber<RoomAction> m_RoomActionSubscriber;

        // sender of actions to the room
        // RoomActionPublisher m_RoomActionPublisher;

        // Scheduler to execute player actions
        Scheduler m_Scheduler;

        // Factory to generate player commands for the scheduler
        protected PlayerCommandFactory m_CommandFactory;
        protected PlayerActionFactory m_MenuActionFactory;

        PlayerModel m_PlayerModel;
        public PlayerModel PlayerModel { get { return m_PlayerModel;}}

        PlayerMenuModel m_PlayerMenu;
        public PlayerMenuModel PlayerMenu { get { return m_PlayerMenu; } }

        
        // Publisher<InputType> m_InputPublisher;
        Subscriber<InputType> m_InputSubscriber;

        IPublisher<InputType> m_InputPublisher;


        public enum State {
            ActiveControls,
            InactiveControls,
            Menu,

        }
        public State m_State;

        protected virtual void Awake(){
            // m_RoomActionSubscriber = new Subscriber<RoomAction>();
            // m_RoomActionPublisher = GetComponent<RoomActionPublisher>();
            // m_Scheduler = GetComponent<Scheduler>();
            m_Scheduler = new Scheduler();
            m_CommandFactory = GetComponent<PlayerCommandFactory>();
            m_MenuActionFactory = GetComponent<PlayerActionFactory>();
            // m_CommandFactory = new PlayerCommandFactory();
            // m_MenuCommandFactory = new MenuCommandFactory();
            // m_CommandFactory = new PlayerCommandFactory();

            // m_RoomActionSubscriber.PublisherAction += OnRoomAction;

            m_PlayerModel = GetComponent<PlayerModel>();

            m_InputSubscriber = new Subscriber<InputType>();

            m_InputPublisher = GetComponent<IPublisher<InputType>>();

            m_PlayerMenu = GetComponentInChildren<PlayerMenuModel>();
        }

        void Start(){
            SubscribeTo(m_InputPublisher);
        }

        void OnDestroy(){
            // m_RoomActionSubscriber.PublisherAction -= OnRoomAction;
        }


        void OnInput(InputType type){
            bool validMenuCommand = type == InputType.ToggleMenu && m_State == State.Menu;
            if (m_State == State.ActiveControls || validMenuCommand){
                PlayerCommandProduct product = new PlayerCommandProduct(this, type);
                Command cmd = m_CommandFactory.Make(product);
                ExecuteCommand(cmd);
            }
        }

        public void SubscribeTo(IPublisher<InputType> publisher){
            publisher.AddListener(OnInput);
        }

        public void UnsubscribeFrom(IPublisher<InputType> publisher){
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
    }
}