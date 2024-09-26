using System.Collections.Generic;
using UnityEngine;

using OSGames.BoardGame.Generic;

namespace OSGames.BoardGame {
    [CreateAssetMenu(fileName = "Room Move Action", menuName = "Board Game/Room Move Action", order = 0)]
    public class MovementAction : RoomAction {

        // define constraints for this action to be valid

        // define constructor/factory for a move command for the room's scheduler

        private Transform m_Destination;

        public Transform Destination {get { return m_Destination; }}

        public Publisher<RoomAction> DestinationRoomPublisher;
        public Publisher<List<RoomAction>> DestinationRoomActionListPublisher;

        public override ActionType GetActionType(){
            return ActionType.Move;
        }

        public void SetDestination(Transform destination){
            m_Destination = destination;
        }

    }

}