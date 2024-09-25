using UnityEngine;

namespace OSGames.BoardGame {

    public interface IMovementIndicator{
        public Transform GetDestination();

        public RoomModel GetDestinationRoom();
    }

}