using UnityEngine;

using OSGames.BoardGame.Generic;

namespace OSGames.BoardGame {

    public interface IMovementIndicator : IInteractable {
        public Transform GetDestination();

        public RoomModel GetDestinationRoom();

    }

}