using UnityEngine;

namespace BoardGame {
    [CreateAssetMenu(fileName = "Room Move Action", menuName = "Board Game/Room Move Action", order = 0)]
    public class MovementAction : RoomAction {

        // define constraints for this action to be valid

        // define constructor/factory for a move command for the room's scheduler

        public override ActionType GetActionType(){
            return ActionType.Move;
        }
    }

}