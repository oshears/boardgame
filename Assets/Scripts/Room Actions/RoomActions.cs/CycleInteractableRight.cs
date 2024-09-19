using UnityEngine;

namespace OSGames.BoardGame {
    [CreateAssetMenu(fileName = "Room Cycle Interactable Right Action", menuName = "Board Game/Room Cycle Interactable Right Action", order = 0)]
    public class CycleInteractableRightAction : SetTargetAction {

        public override ActionType GetActionType(){
            return ActionType.CycleRight;
        }

    }

}