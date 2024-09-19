using UnityEngine;
using UnityEngine.AI;

namespace OSGames.BoardGame {
    public class PlayerMoveCommand : PlayerCommand {

        Transform m_Destination;
        public PlayerMoveCommand(PlayerController playerController, Transform destination) : base(playerController){
            m_Destination = destination;
        }

        override public void Execute(){
            m_PlayerController.PlayerModel.Agent.SetDestination(m_Destination.position);
        }

        

    }

}