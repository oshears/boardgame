using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BoardGame {

    // [RequireComponent(typeof(RoomActionListSubscriber))]
    // [RequireComponent(typeof(CommandFactory))]
    // [RequireComponent(typeof(ButtonFactory))]
    // [RequireComponent(typeof(Scheduler))]
    [RequireComponent(typeof(RoomActionSubscriber))] // recieve commands from the player
    [RequireComponent(typeof(RoomActionListPublisher))] // send available commands to the player HUD
    [RequireComponent(typeof(RoomActionPublisher))] // send commands to the player and the room
    [RequireComponent(typeof(Scheduler))]
    [RequireComponent(typeof(RoomCommandFactory))]
    public class RoomController : Controller<RoomAction>
    {
        [SerializeField] List<RoomAction> m_ActionList = new List<RoomAction>();

        // [SerializeField] RoomController[] m_NeighboringRooms;

        RoomActionListPublisher m_RoomActionListPublisher;
        RoomActionPublisher m_RoomActionPublisher;
        Scheduler m_Scheduler;

        RoomCommandFactory m_CommandFactory;


        // temporary fields for testing
        [SerializeField] Transform m_Destination;
        [SerializeField] NavMeshAgent m_Agent;

        override protected void Awake(){
            base.Awake();
            m_RoomActionListPublisher = GetComponent<RoomActionListPublisher>();
            m_RoomActionPublisher = GetComponent<RoomActionPublisher>();
            m_Scheduler = GetComponent<Scheduler>();
            m_CommandFactory = GetComponent<RoomCommandFactory>();
        }


        // this happens when the publisher sends the selected room action
        override public void OnPublisherAction(RoomAction roomAction) {
            Debug.Log($"Room is responding to the user's chosen action: {roomAction}");

            RoomCommandProduct product = new RoomCommandProduct(this, roomAction);
            Command cmd = m_CommandFactory.Make(product);
            m_Scheduler.AddCommand(cmd);

            // debug, for test
            // probably want to do player movement commands in the player controller?
            m_Scheduler.AddCommand(new RoomMoveCommand(this, m_Agent, m_Destination));
            
            // forward the actions to:
            // room objects
            // player controller
            // noise system
            
            m_RoomActionPublisher.Publish(roomAction);
        }

        public void TestPublish(){
            m_RoomActionListPublisher.Publish(m_ActionList);    
        }

    }
}