using System;
using UnityEngine;
using UnityEngine.AI;

using OSGames.BoardGame;
using OSGames.Utilities.AI;
using System.Collections;

namespace OSGames.BoardGame.Player {
    public class PlayerMoveCommand : PlayerCommand {

        // Transform m_Destination;

        IMovementIndicator m_MovementIndicator;

        public PlayerMoveCommand(PlayerController playerController, IMovementIndicator indicator) : base(playerController){
            // m_Destination = destination;
            // m_Publisher = publisher;
            m_MovementIndicator = indicator;
        }

        override public void Execute(){
            
            // IMovementIndicator indicator = m_PlayerController.PlayerModel.TargetInteractable.GetComponent<IMovementIndicator>();
            m_PlayerController.PlayerModel.Agent.SetDestination(m_MovementIndicator.GetDestination().position);
            m_PlayerController.PlayerModel.Animator.SetTrigger("Move");
            m_PlayerController.PlayerModel.CurrentRoom.RemovePlayer(m_PlayerController.PlayerModel);
            m_PlayerController.PlayerModel.CurrentRoom = m_MovementIndicator.GetDestinationRoom();
            m_PlayerController.PlayerModel.CurrentRoom.RegisterPlayer(m_PlayerController.PlayerModel);
            m_PlayerController.PlayerModel.TargetInteractable = null;

            // m_PlayerController.PublisherToObserve = m_Publisher;
            m_PlayerController.state = PlayerController.State.InactiveControls;
            
            m_PlayerController.PlayerModel.StartCoroutine(AICoroutines.WaitNavMeshArrive(m_PlayerController.PlayerModel.Agent, EnableControls));

            m_PlayerController.PlayerModel.SetMenuCamera(false);
            m_PlayerController.PlayerMenu.SetMenu(false);

            m_MovementIndicator.ClearHighlight();
        }

        void EnableControls() {
            m_PlayerController.state = PlayerController.State.ActiveControls;
        }

        

    }

}