using UnityEngine;

namespace BoardGame {

    [CreateAssetMenu(fileName = "Room Use Action", menuName = "Board Game/Room Use Action", order = 0)]
    public class UseAction : RoomAction {

        // define constraints for this action to be valid

        // define constructor/factory for a use command for the room's scheduler
        public override ActionType GetActionType(){
            return ActionType.Use;
        }
    }

}