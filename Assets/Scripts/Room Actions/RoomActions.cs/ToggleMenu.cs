using UnityEngine;

namespace OSGames.BoardGame {
    [CreateAssetMenu(fileName = "Toggle Menu Action", menuName = "Board Game/Toggle Menu Action", order = 0)]
    public class ToggleMenu : RoomAction {

        bool m_ToggleSetting;
        public bool ToggleSetting{
            get {return m_ToggleSetting;}
            set {m_ToggleSetting = value;}
        }

        public override ActionType GetActionType(){
            return ActionType.ToggleMenu;
        }



    }

}