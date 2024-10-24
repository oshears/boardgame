using UnityEngine;

namespace OSGames.BoardGame {

    public enum ItemWeight {
        Light,
        Heavy,
    }
    
    // [CreateAssetMenu(fileName = "Item", menuName = "Board Game/Item", order = 0)]
    public abstract class Item : ScriptableObject {

        // [SerializeReference, SubclassSelector]
	    // ICommand[] m_Commands;
        //  = Array.Empty<ICommand>();
        public string itemName;
        public string itemDescription;

        /// <summary>
        /// The prefab to display when the item is dropped on the ground of viewed in the item viewer
        /// </summary>
        [SerializeField, Tooltip("The prefab to display when the item is dropped on the ground of viewed in the item viewer")]
        public GameObject itemPrefab;
        
        public ItemWeight itemWeight;
        
        [Tooltip("Indicates whether the item is destroyed after a single use.")]
        public bool isOneUse = true;

        
        
    }
}