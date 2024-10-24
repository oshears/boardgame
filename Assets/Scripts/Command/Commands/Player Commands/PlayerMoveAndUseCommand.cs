
using UnityEngine;
using UnityEngine.AI;
using OSGames.BoardGame.Interactables;

using OSGames.BoardGame;
using OSGames.Utilities.AI;

namespace OSGames.BoardGame.Player {
    public class PlayerMoveAndUseCommand : PlayerCommand {

        public PlayerMoveAndUseCommand(PlayerController playerController) : base(playerController){

        }

        override public void Execute(){

            InteractableModel interactable = PlayerController.TargetInteractable.interactableModel;

            m_PlayerController.PlayerModel.Agent.SetDestination(interactable.GetStandPosition().position);

            m_PlayerController.PlayerModel.StartCoroutine(AICoroutines.WaitNavMeshArrive(m_PlayerController.PlayerModel.Agent, OnNavMeshArrival));

            interactable.ClearHighlight();
        }

        void OnNavMeshArrival(){
            // Execute Typing Animation
            PlayerController.TargetInteractable.interactableModel.Use();
            m_PlayerController.PlayerModel.Animator.SetBool("Typing",true);
            m_PlayerController.PlayerModel.ResetAnimatorAfter(2.5f);
        }

        

    }

}