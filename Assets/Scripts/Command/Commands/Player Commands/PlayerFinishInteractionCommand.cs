using System;
using UnityEngine;
using UnityEngine.AI;

using OSGames.BoardGame;
using OSGames.Utilities.AI;
using System.Collections;

namespace OSGames.BoardGame.Player {
    public class PlayerFinishInteractionCommand : PlayerCommand {
        public PlayerFinishInteractionCommand(PlayerController playerController) : base(playerController){
            
        }

        override public void Execute(){
            Debug.Log("Enabling player controls!");
            m_PlayerController.state = PlayerController.State.ActiveControls;
        }

    }

}