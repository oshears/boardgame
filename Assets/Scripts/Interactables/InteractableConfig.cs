using UnityEngine;

namespace OSGames.BoardGame.Interactables {

    [CreateAssetMenu(fileName = "Interactable Config", menuName = "Board Game/Interactable Config", order = 0)]
    public class InteractableConfig : ScriptableObject {

        public InteractableType InteractableType;
        public GameObject InteractablePrefab;

    }

}