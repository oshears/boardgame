using System;
using UnityEngine;
using UnityEngine.AI;

using OSGames.BoardGame;
using OSGames.Utilities.AI;
using System.Collections;

using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Actions;
using OSGames.BoardGame.Interactables;

namespace OSGames.BoardGame.Player {
    public class PlayerInteractCommand : PlayerCommand {

        // Transform m_Destination;

        IActionInteractable m_Interactable;

        public PlayerInteractCommand(PlayerController playerController, IActionInteractable interactable) : base(playerController){
            m_Interactable = interactable;
        }

        override public void Execute(){
            PlayerAction action = m_Interactable.GetPlayerAction();
        }

    }

}