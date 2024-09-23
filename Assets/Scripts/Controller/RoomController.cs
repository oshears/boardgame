using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;
using OSGames.BoardGame.Generic;

namespace OSGames.BoardGame {

    // [RequireComponent(typeof(RoomActionListSubscriber))]
// [RequireComponent(typeof(CommandFactory))]
    // [RequireComponent(typeof(ButtonFactory))]
    // [RequireComponent(typeof(Scheduler))]
    [RequireComponent(typeof(RoomActionSubscriber))] // recieve commands from the player
    [RequireComponent(typeof(RoomActionListPublisher))] // send available commands to the player HUD
    [RequireComponent(typeof(RoomActionPublisher))] // send commands to the player and the room
    [RequireComponent(typeof(Scheduler))]
    [RequireComponent(typeof(RoomCommandFactory))]
    [RequireComponent(typeof(RoomCommandFactory))]
    [RequireComponent(typeof(RoomModel))]
    public class RoomController : Controller
    {
        [SerializeField] List<RoomAction> m_ActionList = new List<RoomAction>();

        // [SerializeField] List<PlayerController> m_PlayersInRoom;
        // [SerializeField] PlayerController m_CurrentPlayer;

        // [SerializeField] RoomController[] m_NeighboringRooms;

        [HideInInspector]
        public RoomActionSubscriber m_PlayerHUDRoomActionSubscriber;
        [HideInInspector]
        public RoomActionSubscriber m_PlayerInputRoomActionSubscriber;
        RoomActionListPublisher m_RoomActionListPublisher;
        public RoomActionListPublisher RoomActionListPublisher { get {return m_RoomActionListPublisher;} }
        RoomActionPublisher m_RoomActionPublisher;
        public RoomActionPublisher RoomActionPublisher { get {return m_RoomActionPublisher;} }
        Scheduler m_Scheduler;

        RoomCommandFactory m_CommandFactory;

        RoomModel m_RoomModel;
        public RoomModel RoomModel { get { return m_RoomModel;}}



        void Awake(){
            m_RoomActionListPublisher = GetComponent<RoomActionListPublisher>();
            m_RoomActionPublisher = GetComponent<RoomActionPublisher>();
            m_Scheduler = GetComponent<Scheduler>();
            m_CommandFactory = GetComponent<RoomCommandFactory>();

            // NOTE: the inspector order matters. Might want to change this in the future
            RoomActionSubscriber[] subs = GetComponents<RoomActionSubscriber>();
            m_PlayerHUDRoomActionSubscriber = subs[0];
            m_PlayerHUDRoomActionSubscriber.PublisherAction += OnPlayerAction;
            
            m_PlayerInputRoomActionSubscriber = subs[1];
            m_PlayerInputRoomActionSubscriber.PublisherAction += OnPlayerAction;

            m_RoomModel = GetComponent<RoomModel>();
        }

        void OnDestroy(){
            m_PlayerHUDRoomActionSubscriber.PublisherAction -= OnPlayerAction;
            m_PlayerInputRoomActionSubscriber.PublisherAction -= OnPlayerAction;
        }


        // this happens when the publisher sends the selected room action
        public void OnPlayerAction(RoomAction roomAction) {
            Debug.Log($"Room is responding to the user's chosen action: {roomAction}");

            RoomCommandProduct product = new RoomCommandProduct(this, roomAction);
            Command cmd = m_CommandFactory.Make(product);
            m_Scheduler.ExecuteCommand(cmd);
            m_RoomActionPublisher.Publish(roomAction);

            // debug, for test
            // probably want to do player movement commands in the player controller?
            // m_Scheduler.AddCommand(new RoomMoveCommand(this, m_RoomModel.GetNeighboringPlayerStandTransform(0)));
            
            // forward the actions to:
            // room objects
            // player controller
            // noise system
            
        }

        public void TestPublish(){
            m_RoomActionListPublisher.Publish(m_ActionList);    
        }

    }
}