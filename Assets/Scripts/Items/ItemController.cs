using UnityEngine;
using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Interactables;

namespace OSGames.BoardGame {
    
    [RequireComponent(typeof(ItemModel))]
    public class ItemController : InteractableController, IItem {
        
        ItemModel m_ItemModel;
        public ItemModel itemModel {
            get { return m_ItemModel; }
        }

        Item m_ItemData;
        public virtual Item itemData {
            get {return m_ItemData;}
            set {m_ItemData = value;}
        }

        override protected void Awake(){
            base.Awake();
            m_ItemModel = GetComponent<ItemModel>();
        }



        public void Pickup(){
            Destroy(gameObject);
        }

        public void Drop(){

        }


    }
}