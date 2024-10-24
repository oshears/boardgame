using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

using OSGames.BoardGame.Interactables;
// using D

using OSGames.BoardGame;

namespace OSGames.BoardGame.Player {
    
    public class PlayerToggleMenuCommand : PlayerCommand {
        
        bool m_OpenMenu;
        public PlayerToggleMenuCommand(PlayerController playerController) : base(playerController){
            m_OpenMenu = !playerController.PlayerMenu.MenuActive;
        }

        public PlayerToggleMenuCommand(PlayerController playerController, bool openMenu) : base(playerController){
            m_OpenMenu = openMenu;
        }

        override public void Execute(){
            m_PlayerController.PlayerMenu.SetMenu(m_OpenMenu);
            m_PlayerController.PlayerModel.SetMenuCamera(m_OpenMenu);
            m_PlayerController.state = m_OpenMenu ? PlayerController.State.ViewingMenu : PlayerController.State.ActiveControls;
            if (m_OpenMenu) m_PlayerController.RefreshActions();
        }
    }
}