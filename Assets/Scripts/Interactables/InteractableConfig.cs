using OSGames.BoardGame.Actions;
using UnityEngine;

namespace OSGames.BoardGame.Interactables {

    // [CreateAssetMenu(fileName = "Interactable Config", menuName = "Board Game/Interactable Config", order = 0)]
    public class InteractableConfig : ScriptableObject, IActionHolder {

        public string interactableName;
        
        [TextArea]
        public string interactableDescription;

        [TextArea]
        public string hint;

        public InteractableType InteractableType;
        public GameObject InteractablePrefab;

        PlayerAction m_PlayerAction;
        public virtual PlayerAction playerAction {get {return m_PlayerAction;}}

        public PlayerAction GetPlayerAction() => m_PlayerAction;

        public void SetPlayerAction(PlayerAction action)
        {
            m_PlayerAction = action; 
        }
    }

}