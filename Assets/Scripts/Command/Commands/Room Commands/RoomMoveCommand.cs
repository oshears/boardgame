using UnityEngine;
using UnityEngine.AI;

namespace OSGames.BoardGame {
    public class RoomMoveCommand : RoomCommand {

        public RoomMoveCommand(RoomController roomController, RoomAction roomAction) : base(roomController, roomAction){

        }

        override public void Execute(){
            
            // Create a new move action
            // store the publisher information of the next room so that the player and player hud can subscribe to it
            // MovementAction moveAction = ScriptableObject.CreateInstance<MovementAction>();
            // moveAction.DestinationRoomPublisher = m_RoomController.RoomModel.GetNeighboringRoom(0).GetComponent<RoomController>().RoomActionPublisher;
            // moveAction.DestinationRoomActionListPublisher = m_RoomController.RoomModel.GetNeighboringRoom(0).GetComponent<RoomController>().RoomActionListPublisher;
            // moveAction.SetDestination(m_RoomController.RoomModel.GetNeighboringPlayerStandTransform(0));
            // m_RoomController.RoomActionPublisher.Publish(moveAction);

            // // Unsubscibe from the player HUD's actions
            // // subscrube the next room to the current room's settings for player HUD observer
            // Publisher<RoomAction> pub = m_RoomController.m_PlayerHUDRoomActionSubscriber.PublisherToObserve;
            // m_RoomController.RoomModel.GetNeighboringRoom(0).GetComponent<RoomController>().m_PlayerHUDRoomActionSubscriber.PublisherToObserve = pub;
            // m_RoomController.m_PlayerHUDRoomActionSubscriber.PublisherToObserve = null;

            // // Unsubscibe from the player's actions
            // // subscrube the next room to the current room's settings for player observer
            // pub = m_RoomController.m_PlayerInputRoomActionSubscriber.PublisherToObserve;
            // m_RoomController.RoomModel.GetNeighboringRoom(0).GetComponent<RoomController>().m_PlayerInputRoomActionSubscriber.PublisherToObserve = pub;
            // m_RoomController.m_PlayerInputRoomActionSubscriber.PublisherToObserve = null;


            // TODO: perform any other actions to reset this room to its original state here

            // MovementAction moveAction = (MovementAction) RoomAction;

            // broadcast a player action to move
            // Transform destination = m_RoomController.RoomModel.GetNeighboringPlayerStandTransform(0);
            // moveAction.SetDestination(destination);

            // now broadcast this action
            // m_RoomController.RoomActionPublisher.Publish(moveAction);
        }

        

    }

}