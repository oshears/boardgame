using UnityEngine;

namespace OSGames.BoardGame {
    [CreateAssetMenu(fileName = "Room Move Action", menuName = "Board Game/Room Move Action", order = 0)]
    public class MoveAndUseAction : MovementAction {


        public override ActionType GetActionType(){
            return ActionType.MoveAndUse;
        }
    }
}