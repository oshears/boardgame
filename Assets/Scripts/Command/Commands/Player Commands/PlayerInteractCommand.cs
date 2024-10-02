using System;
using UnityEngine;
using UnityEngine.AI;

using OSGames.BoardGame;
using OSGames.Utilities.AI;
using System.Collections;

using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Interactables;

namespace OSGames.BoardGame.Player {
    public class PlayerInteractCommand : PlayerCommand {

        // Transform m_Destination;

        ICycleableInteractable m_Interactable;

        public PlayerInteractCommand(PlayerController playerController, ICycleableInteractable interactable) : base(playerController){
            m_Interactable = interactable;
        }

        override public void Execute(){
            // if (m_Interactable.TryGetComponent<IBasicActionHolder>(out IBasicActionHolder basicActionHolder)){
            //     Debug.Log(basicActionHolder);
            // }
        }

    }

}