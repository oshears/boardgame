using UnityEngine;
using OSGames.BoardGame.Generic;
using MackySoft.SerializeReferenceExtensions;
using System;
using System.Collections.Generic;

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
        public GameObject itemPrefab;
        public ItemWeight itemWeight;
        [Tooltip("Indicates whether the item is destroyed after a single use.")]
        public bool isOneUse = true;

        
        
    }
}