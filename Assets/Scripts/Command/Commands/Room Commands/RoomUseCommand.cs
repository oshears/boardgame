using UnityEngine;
using UnityEngine.AI;

namespace OSGames.BoardGame {
    public class RoomUseCommand : RoomCommand {

        public RoomUseCommand(RoomController roomController, RoomAction roomAction) : base(roomController, roomAction){

        }

        override public void Execute(){
            Debug.Log($"Player used the interactable: {m_RoomController.RoomModel.TargetedInteractable}");

            MoveAndUseAction moveAction = ScriptableObject.CreateInstance<MoveAndUseAction>();
            moveAction.SetDestination(m_RoomController.RoomModel.TargetedInteractable.PlayerStandingPoint);
            m_RoomController.RoomActionPublisher.Publish(moveAction);

        }

        

    }

}