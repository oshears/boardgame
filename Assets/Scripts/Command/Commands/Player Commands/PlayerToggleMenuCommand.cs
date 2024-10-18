using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

using OSGames.BoardGame.Interactables;
// using D

using OSGames.BoardGame;

namespace OSGames.BoardGame.Player {
    
    public class PlayerToggleMenuCommand : PlayerCommand {
        
        bool m_OpenMenu;
        bool m_Toggle;
        public PlayerToggleMenuCommand(PlayerController playerController) : base(playerController){
            m_Toggle = true;
        }

        public PlayerToggleMenuCommand(PlayerController playerController, bool openMenu) : base(playerController){
            m_OpenMenu = openMenu;
            m_Toggle = false;
        }

        override public void Execute(){
            if (m_Toggle){
                bool menuActive = m_PlayerController.PlayerMenu.ToggleMenu();
                m_PlayerController.PlayerModel.SetMenuCamera(menuActive);
                m_PlayerController.state = menuActive ? PlayerController.State.Menu : PlayerController.State.ActiveControls;
            }
            else{
                m_PlayerController.PlayerMenu.SetMenu(m_OpenMenu);
                m_PlayerController.PlayerModel.SetMenuCamera(m_OpenMenu);
                m_PlayerController.state = m_OpenMenu ? PlayerController.State.Menu : PlayerController.State.ActiveControls;
            }
            
        }
    }
}