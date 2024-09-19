using UnityEngine;
using UnityEngine.AI;

namespace OSGames.BoardGame {
    public class RoomCycleInteractableRightCommand : RoomCommand {

        public RoomCycleInteractableRightCommand(RoomController roomController, RoomAction roomAction) : base(roomController, roomAction){

        }


        override public void Execute(){

            // // broadcast a player action to move
            // Transform destination = m_RoomController.RoomModel.GetNeighboringPlayerStandTransform(0);
            // roomAction.SetDestination(destination);

            // // now broadcast this action
            // m_RoomActionPublisher.Publish(roomAction);
            if (m_RoomController.RoomModel.TargetedInteractable){
                SetTargetAction setTargetAction = (SetTargetAction) RoomAction;

                setTargetAction.OldTarget = m_RoomController.RoomModel.TargetedInteractable.transform;
                setTargetAction.NewTarget = m_RoomController.RoomModel.TargetedInteractable.NextInteractable.transform;


                // for now this is ok, but this should probably be moved later (local to the interactable)
                m_RoomController.RoomModel.TargetedInteractable.ClearHighlight();
                m_RoomController.RoomModel.TargetedInteractable = m_RoomController.RoomModel.TargetedInteractable.NextInteractable;
                m_RoomController.RoomModel.TargetedInteractable.SetHighlight();

                

                m_RoomController.RoomActionPublisher.Publish(setTargetAction);
            }
            else{
                m_RoomController.RoomModel.TargetedInteractable = m_RoomController.RoomModel.InitialInteractable;
                m_RoomController.RoomModel.TargetedInteractable.SetHighlight();
            }

            // TODO: consider sending an additional command to change the camera perspective

        }

    }
}