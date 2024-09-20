
using UnityEngine;
using UnityEngine.AI;

namespace OSGames.BoardGame {
    public class PlayerMoveAndUseCommand : PlayerCommand {

        Transform m_Destination;

        NavMeshAgent m_Agent;
        Animator m_Animator;

        public PlayerMoveAndUseCommand(PlayerController playerController, Transform destination) : base(playerController){
            m_Destination = destination;
        }

        override public void Execute(){
            m_Agent = m_PlayerController.PlayerModel.Agent;
            m_Agent.SetDestination(m_Destination.position);

            m_Agent = m_PlayerController.PlayerModel.Agent;
            m_Animator = m_PlayerController.PlayerModel.Animator;

            m_PlayerController.PlayerModel.ExecuteOnNavMeshArrival(OnNavMeshArrival);
        }

        void OnNavMeshArrival(){
            // Execute Typing Animation
            m_Animator.SetBool("Typing",true);
            m_PlayerController.PlayerModel.ResetAnimatorAfter(5f);
        }

        

    }

}