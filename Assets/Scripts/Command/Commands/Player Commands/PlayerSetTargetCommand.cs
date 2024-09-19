using UnityEngine;
using UnityEngine.AI;

namespace OSGames.BoardGame {
    public class PlayerSetTargetCommand : PlayerCommand {

        Transform m_Target;

        public PlayerSetTargetCommand(PlayerController playerController, Transform target) : base(playerController){
            m_Target = target;
        }

        override public void Execute(){

            // rotate player to look at the interactable
            m_PlayerController.transform.LookAt(m_Target);

            // TODO: what if the alien is blocking the way?? what if the players can't see past it?? or other players??
            // maybe it'd be a good idea to have the alternative top view for this case
            m_PlayerController.PlayerModel.TargetInteractable = m_Target.GetComponent<InteractableController>();

        }

        

    }

}