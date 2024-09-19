using UnityEngine;
using UnityEngine.AI;

namespace OSGames.BoardGame {
    public class RoomMoveCommand : RoomCommand {

        public RoomMoveCommand(RoomController roomController, RoomAction roomAction) : base(roomController, roomAction){

        }

        override public void Execute(){

            MovementAction moveAction = (MovementAction) RoomAction;

            // broadcast a player action to move
            Transform destination = m_RoomController.RoomModel.GetNeighboringPlayerStandTransform(0);
            moveAction.SetDestination(destination);

            // now broadcast this action
            m_RoomController.RoomActionPublisher.Publish(moveAction);
        }

        

    }

}