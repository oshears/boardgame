using OSGames.BoardGame.Actions;
using UnityEngine;

namespace OSGames.BoardGame.Interactables {

    [CreateAssetMenu(fileName = "Interactable Config", menuName = "Board Game/Interactable Config", order = 0)]
    public class InteractableConfig : ScriptableObject, IActionHolder {

        public InteractableType InteractableType;
        public GameObject InteractablePrefab;

        [SerializeField] PlayerAction m_PlayerAction;
        public PlayerAction playerAction {get {return m_PlayerAction;}}

        public PlayerAction GetPlayerAction() => m_PlayerAction;

        public void SetPlayerAction(PlayerAction action)
        {
            m_PlayerAction = action; 
        }
    }

}