using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

using OSGames.BoardGame.Interactables;
// using D

using OSGames.BoardGame;

namespace OSGames.BoardGame.Player {
    
    public class PlayerToggleMenuCommand : PlayerCommand {

        public PlayerToggleMenuCommand(PlayerController playerController) : base(playerController){
        
        }

        override public void Execute(){
            bool menuActive = m_PlayerController.PlayerMenu.ToggleMenu();
            m_PlayerController.PlayerModel.SetMenuCamera(menuActive);
        }
    }
}