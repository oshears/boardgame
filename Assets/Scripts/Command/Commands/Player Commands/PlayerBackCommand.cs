
using UnityEngine;
using UnityEngine.AI;
using OSGames.BoardGame.Interactables;

using OSGames.BoardGame;
using OSGames.Utilities.AI;

namespace OSGames.BoardGame.Player {
    public class PlayerBackCommand : PlayerCommand {

        public PlayerBackCommand(PlayerController playerController) : base(playerController){

        }

        override public void Execute(){
            if (m_PlayerController.PlayerMenu.MenuActive && m_PlayerController.PlayerMenu.GetAtBaseMenu()){
                ClearMenu();
                ResetPlayer();
            }
        }

        public void ClearMenu(){
            m_PlayerController.PlayerMenu.SetMenu(false);
        }

        public void ResetPlayer(){
            m_PlayerController.PlayerModel.SetMenuCamera(false);
            m_PlayerController.m_State = PlayerController.State.ActiveControls;
        }

        

    }

}