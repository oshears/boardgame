using System;
using UnityEngine;
using UnityEngine.AI;

using OSGames.BoardGame;

namespace OSGames.BoardGame.Player {
    public class PlayerSetControls : PlayerCommand {

        bool m_ControlsActive;
        
        public PlayerSetControls(PlayerController playerController, bool controlsActive) : base(playerController){
            bool m_ControlsActive = controlsActive;
        }

        override public void Execute() {
            if (m_ControlsActive) {
                m_PlayerController.m_State = PlayerController.State.ActiveControls;
            }
            else{
                m_PlayerController.m_State = PlayerController.State.InactiveControls;
            }
        }


    }
}