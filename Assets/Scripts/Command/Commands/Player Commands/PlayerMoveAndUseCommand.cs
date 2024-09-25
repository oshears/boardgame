
using UnityEngine;
using UnityEngine.AI;
using OSGames.BoardGame.Interactables;

using OSGames.BoardGame;

namespace OSGames.BoardGame.Player {
    public class PlayerMoveAndUseCommand : PlayerCommand {

        public PlayerMoveAndUseCommand(PlayerController playerController) : base(playerController){

        }

        override public void Execute(){

            InteractableModel interactable = PlayerController.PlayerModel.TargetInteractable;

            m_PlayerController.PlayerModel.Agent.SetDestination(interactable.PlayerStandingPoint.position);

            m_PlayerController.PlayerModel.ExecuteOnNavMeshArrival(OnNavMeshArrival);
        }

        void OnNavMeshArrival(){
            // Execute Typing Animation
            PlayerController.PlayerModel.TargetInteractable.Use();
            m_PlayerController.PlayerModel.Animator.SetBool("Typing",true);
            m_PlayerController.PlayerModel.ResetAnimatorAfter(2.5f);
        }

        

    }

}