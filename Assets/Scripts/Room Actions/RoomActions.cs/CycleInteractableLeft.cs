using UnityEngine;

namespace OSGames.BoardGame {
    [CreateAssetMenu(fileName = "Room Cycle Interactable Left Action", menuName = "Board Game/Room Cycle Interactable Left Action", order = 0)]
    public class CycleInteractableLeftAction : SetTargetAction {

        public override ActionType GetActionType(){
            return ActionType.CycleLeft;
        }

    }

}