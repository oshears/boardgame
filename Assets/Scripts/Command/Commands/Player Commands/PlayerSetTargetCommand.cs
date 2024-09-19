using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
// using D

namespace OSGames.BoardGame {
    public class PlayerSetTargetCommand : PlayerCommand {

        Transform m_Target;

        public PlayerSetTargetCommand(PlayerController playerController, Transform target) : base(playerController){
            m_Target = target;
        }

        override public void Execute(){

            // rotate player to look at the interactable
            // m_PlayerController.transform.LookAt(m_Target);
            // m_m_PlayerController.transform.position
            
            //find the vector pointing from our position to the target
            Vector3 direction = (m_Target.position - m_PlayerController.transform.position).normalized;
            //create the rotation we need to be in to look at the target
            Quaternion _lookRotation = Quaternion.LookRotation(direction);
            
            if (m_Target.rotation.eulerAngles.y - _lookRotation.eulerAngles.y > 0){
                m_PlayerController.PlayerModel.Animator.SetInteger("Rotating Direction",1);
            }
            else{
                m_PlayerController.PlayerModel.Animator.SetInteger("Rotating Direction",-1);
            }
            m_PlayerController.PlayerModel.Animator.SetBool("Rotating",true);
            Tweener tweener = m_PlayerController.transform.DOLookAt(m_Target.position,0.5f).OnComplete(() => {
                m_PlayerController.PlayerModel.Animator.SetBool("Rotating",false);
            });

            // TODO: what if the alien is blocking the way?? what if the players can't see past it?? or other players??
            // maybe it'd be a good idea to have the alternative top view for this case
            m_PlayerController.PlayerModel.TargetInteractable = m_Target.GetComponent<InteractableController>();


            m_PlayerController.PlayerModel.e_RotatePlayer.Invoke();
        }

        

    }

}