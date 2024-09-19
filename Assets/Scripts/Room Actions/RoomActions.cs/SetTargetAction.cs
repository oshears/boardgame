using UnityEngine;

namespace OSGames.BoardGame {
    [CreateAssetMenu(fileName = "Room Set Target Action", menuName = "Board Game/Room Set Target Action", order = 0)]
    public class SetTargetAction : RoomAction {

        // define constraints for this action to be valid

        // define constructor/factory for a move command for the room's scheduler

        private Transform m_OldTarget;
        public Transform OldTarget {
            get { return m_OldTarget;}
            set { m_OldTarget = value;}
        }
        private Transform m_NewTarget;
        public Transform NewTarget {
            get { return m_NewTarget;}
            set { m_NewTarget = value;}
        }

        public override ActionType GetActionType(){
            return ActionType.Move;
        }

    }

}