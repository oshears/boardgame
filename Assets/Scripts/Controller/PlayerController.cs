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


        public enum State {
            ActiveControls,
            InactiveControls,
            Menu,

        }
        public State m_State;

        protected virtual void Awake(){
            m_Scheduler = new Scheduler();
            m_CommandFactory = GetComponent<PlayerCommandFactory>();
            m_MenuActionFactory = GetComponent<PlayerActionFactory>();

            m_PlayerModel = GetComponent<PlayerModel>();

            m_InputPublisher = GetComponent<IPublisher<InputType>>();

            m_PlayerMenu = GetComponentInChildren<PlayerMenuModel>();
        }

        void Start(){
            SubscribeTo(m_InputPublisher);
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
    }
}