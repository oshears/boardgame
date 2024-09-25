using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
// using D

using OSGames.BoardGame;

namespace OSGames.BoardGame.Player {
    
    public class PlayerToggleCameraCommand : PlayerCommand {


        public PlayerToggleCameraCommand(PlayerController playerController) : base(playerController){

        }

        override public void Execute(){
            m_PlayerController.PlayerModel.ToggleCamera();
        }
    }
}