using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;
using OSGames.BoardGame.Generic;

namespace OSGames.BoardGame {

    [RequireComponent(typeof(RoomActionSubscriber))] 
    // [RequireComponent(typeof(RoomActionPublisher))]
    [RequireComponent(typeof(Scheduler))]
    [RequireComponent(typeof(PlayerCommandFactory))]
    [RequireComponent(typeof(PlayerModel))]
    public class PlayerController : Controller
    {

        // subscriber to actions received from game menu / room
        public RoomActionSubscriber m_RoomActionSubscriber;

        // sender of actions to the room
        // RoomActionPublisher m_RoomActionPublisher;

        // Scheduler to execute player actions
        Scheduler m_Scheduler;

        // Factory to generate player commands for the scheduler
        PlayerCommandFactory m_CommandFactory;

        PlayerModel m_PlayerModel;

        public PlayerModel PlayerModel { get { return m_PlayerModel;}}

        void Awake(){
            m_RoomActionSubscriber = GetComponent<RoomActionSubscriber>();
            // m_RoomActionPublisher = GetComponent<RoomActionPublisher>();
            m_Scheduler = GetComponent<Scheduler>();
            m_CommandFactory = GetComponent<PlayerCommandFactory>();

            m_RoomActionSubscriber = GetComponent<RoomActionSubscriber>();
            m_RoomActionSubscriber.PublisherAction += OnRoomAction;

            m_PlayerModel = GetComponent<PlayerModel>();
        }

        void OnDestroy(){
            m_RoomActionSubscriber.PublisherAction -= OnRoomAction;
        }

        void OnRoomAction(RoomAction roomAction){
            Debug.Log($"Player is responding to the user's chosen action: {roomAction}");

            PlayerCommandProduct product = new PlayerCommandProduct(this, roomAction);
            Command cmd = m_CommandFactory.Make(product);
            m_Scheduler.AddCommand(cmd);

            // test only
            // m_Scheduler.AddCommand(new PlayerMoveCommand(this, m_RoomModel.GetNeighboringPlayerStandTransform(0)));

            // execute some logic based on the room action

            // use factor to figure out which command to generate

            // add the command to the scheduler
        }

    }
}