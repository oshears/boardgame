using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

using OSGames.BoardGame.Interactables;
// using D

using OSGames.BoardGame;

namespace OSGames.BoardGame.Player {
    
    public class PlayerSetTargetCommand : PlayerCommand {

        bool m_TowardsRight;

        public PlayerSetTargetCommand(PlayerController playerController, bool towardsRight) : base(playerController){
            m_TowardsRight = towardsRight;
        }

        override public void Execute(){

            // rotate player to look at the interactable
            // m_PlayerController.transform.LookAt(m_Target);
            // m_m_PlayerController.transform.position
            ICycleableInteractable interactable = m_PlayerController.PlayerModel.TargetInteractable;
            if (interactable != null){
                // for now this is ok, but this should probably be moved later (local to the interactable)
                interactable.ClearHighlight();
                interactable = m_TowardsRight ? interactable.GetNext() : interactable.GetPrev();
                
                // m_PlayerController.PlayerModel.RoomModel.TargetedInteractable = interactable;
                interactable.SetHighlight();
            }
            else{
                interactable = m_PlayerController.CurrentRoom.RoomModel.InitialInteractable;
                interactable.SetHighlight();
            }

            m_PlayerController.PlayerModel.TargetInteractable = interactable;

            Transform  target = interactable.GetLookPosition().transform;
            
            //find the vector pointing from our position to the target
            Vector3 direction = (target.position - m_PlayerController.transform.position).normalized;
            //create the rotation we need to be in to look at the target
            Quaternion _lookRotation = Quaternion.LookRotation(direction);
            
            if (target.rotation.eulerAngles.y - _lookRotation.eulerAngles.y > 0){
                m_PlayerController.PlayerModel.Animator.SetInteger("Rotating Direction",1);
            }
            else{
                m_PlayerController.PlayerModel.Animator.SetInteger("Rotating Direction",-1);
            }
            m_PlayerController.PlayerModel.Animator.SetBool("Rotating",true);
            Tweener tweener = m_PlayerController.transform.DOLookAt(target.position,0.5f,AxisConstraint.Y).OnComplete(() => {
                m_PlayerController.PlayerModel.Animator.SetBool("Rotating",false);
            });

            // TODO: what if the alien is blocking the way?? what if the players can't see past it?? or other players??
            // maybe it'd be a good idea to have the alternative top view for this case
            // m_PlayerController.PlayerModel.TargetInteractable = target.GetComponent<InteractableModel>();


            m_PlayerController.PlayerModel.e_RotatePlayer.Invoke();
        }

        

    }

}