using UnityEngine;
using UnityEngine.AI;

namespace OSGames.BoardGame {
    public class RoomCycleInteractableLeftCommand : RoomCommand {

        public RoomCycleInteractableLeftCommand(RoomController roomController, RoomAction roomAction) : base(roomController, roomAction){

        }


        override public void Execute(){

            // // broadcast a player action to move
            // Transform destination = m_RoomController.RoomModel.GetNeighboringPlayerStandTransform(0);
            // roomAction.SetDestination(destination);

            // // now broadcast this action
            // m_RoomActionPublisher.Publish(roomAction);

            SetTargetAction setTargetAction = (SetTargetAction) RoomAction;

            if (m_RoomController.RoomModel.TargetedInteractable){

                setTargetAction.OldTarget = m_RoomController.RoomModel.TargetedInteractable.transform;
                setTargetAction.NewTarget = m_RoomController.RoomModel.TargetedInteractable.PrevInteractable.transform;

                // for now this is ok, but this should probably be moved later (local to the interactable)
                m_RoomController.RoomModel.TargetedInteractable.ClearHighlight();
                m_RoomController.RoomModel.TargetedInteractable = m_RoomController.RoomModel.TargetedInteractable.PrevInteractable;
                m_RoomController.RoomModel.TargetedInteractable.SetHighlight();
            }
            else{
                setTargetAction.NewTarget = m_RoomController.RoomModel.InitialInteractable.transform;
                m_RoomController.RoomModel.TargetedInteractable = m_RoomController.RoomModel.InitialInteractable;
                m_RoomController.RoomModel.TargetedInteractable.SetHighlight();
            }

            m_RoomController.RoomActionPublisher.Publish(setTargetAction);
            

            // TODO: consider sending an additional command to change the camera perspective

        }

    }
}