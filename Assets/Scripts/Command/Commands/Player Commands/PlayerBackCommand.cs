
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
                bool menuActive = m_PlayerController.PlayerMenu.ToggleMenu();
                m_PlayerController.PlayerModel.SetMenuCamera(menuActive);
                m_PlayerController.m_State = menuActive ? PlayerController.State.Menu : PlayerController.State.ActiveControls;
            }
        }

        

    }

}