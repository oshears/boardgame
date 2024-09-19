using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
// using D

namespace OSGames.BoardGame {
    public class PlayerToggleCameraCommand : PlayerCommand {


        public PlayerToggleCameraCommand(PlayerController playerController) : base(playerController){

        }

        override public void Execute(){
            m_PlayerController.PlayerModel.ToggleCamera();
        }
    }
}