using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Input;
using OSGames.BoardGame.Player;
using UnityEditorInternal;

namespace OSGames.BoardGame {

    [RequireComponent(typeof(PlayerModel))]
    public class PlayerController : Controller, ISubscriber<InputType>
    {

        // subscriber to actions received from game menu / room
        public Subscriber<RoomAction> m_RoomActionSubscriber;

        // sender of actions to the room
        // RoomActionPublisher m_RoomActionPublisher;

        // Scheduler to execute player actions
        Scheduler m_Scheduler;

        // Factory to generate player commands for the scheduler
        PlayerCommandFactory m_CommandFactory;

        PlayerModel m_PlayerModel;
        public PlayerModel PlayerModel { get { return m_PlayerModel;}}

        ActionMenuModel m_PlayerMenu;
        public ActionMenuModel PlayerMenu { get { return m_PlayerMenu; } }


        // Publisher<InputType> m_InputPublisher;
        Subscriber<InputType> m_InputSubscriber;

        IPublisher<InputType> m_InputPublisher;


        public enum State {
            ActiveControls,
            InactiveControls,

        }
        public State m_State;

        void Awake(){
            m_RoomActionSubscriber = new Subscriber<RoomAction>();
            // m_RoomActionPublisher = GetComponent<RoomActionPublisher>();
            // m_Scheduler = GetComponent<Scheduler>();
            m_Scheduler = new Scheduler();
            m_CommandFactory = GetComponent<PlayerCommandFactory>();
            // m_CommandFactory = new PlayerCommandFactory();

            // m_RoomActionSubscriber.PublisherAction += OnRoomAction;

            m_PlayerModel = GetComponent<PlayerModel>();

            m_InputSubscriber = new Subscriber<InputType>();

            m_InputPublisher = GetComponent<IPublisher<InputType>>();

            m_PlayerMenu = GetComponentInChildren<ActionMenuModel>();
        }

        void Start(){
            SubscribeTo(m_InputPublisher);
        }

        void OnDestroy(){
            // m_RoomActionSubscriber.PublisherAction -= OnRoomAction;
        }


        void OnInput(InputType type){
            if (m_State == State.ActiveControls){
                PlayerCommandProduct product = new PlayerCommandProduct(this, type);
                Command cmd = m_CommandFactory.Make(product);
                m_Scheduler.ExecuteCommand(cmd);
            }
            
        }

        public void SubscribeTo(IPublisher<InputType> publisher){
            publisher.AddListener(OnInput);
        }

        public void UnsubscribeFrom(IPublisher<InputType> publisher){
            publisher.RemoveListener(OnInput);
        }

    }
}