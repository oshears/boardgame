
using UnityEngine;
using UnityEngine.AI;
using OSGames.BoardGame.Interactables;

using OSGames.BoardGame;
using OSGames.BoardGame.Player;

namespace OSGames.BoardGame.Player {
    public class PlayerActionCommand : PlayerCommand {

        public PlayerActionCommand(PlayerController playerController) : base(playerController){

        }

        public override void Execute()
        {
            // base.Execute();
            Debug.Log($"Executed Player Action: {this}");
            HideMenu();
        }

        protected void HideMenu(){
            m_PlayerController.PlayerMenu.SetMenu(false);
            m_PlayerController.PlayerModel.SetMenuCamera(false);
        }

    }
}

