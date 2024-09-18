using UnityEngine;

namespace BoardGame {

    // [CreateAssetMenu(fileName = "Room Action", menuName = "Board Game/Room Action", order = 0)]
    public class RoomAction : ScriptableObject {

        // define constraints for this action to be valid

        [SerializeField] public Sprite Sprite;
        [SerializeField] public string Title;
        [SerializeField] public string Description;
        [SerializeField] public int Cost;

        private ActionType m_ActionType;
        
        public ActionType ActionType {
            get {return GetActionType();}
        }

        public virtual ActionType GetActionType(){
            return m_ActionType;
        } 
        
    }

}