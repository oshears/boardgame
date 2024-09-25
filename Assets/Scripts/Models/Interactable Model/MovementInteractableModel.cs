using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

using OSGames.BoardGame;
using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Interactables;

namespace OSGames.BoardGame {

    public class MovementInteractableModel : InteractableModel, IMovementIndicator {

        [SerializeField] RoomModel m_DestinationRoom;
        public Transform GetDestination(){
            return m_DestinationRoom.GetPlayerStandTransform();
        }

        public RoomModel GetDestinationRoom(){
            return m_DestinationRoom;
        }

    }

}