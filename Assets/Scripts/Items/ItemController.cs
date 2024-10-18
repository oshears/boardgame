using UnityEngine;
using OSGames.BoardGame.Generic;
using MackySoft.SerializeReferenceExtensions;
using System;
using System.Collections.Generic;
using OSGames.BoardGame.Interactables;

namespace OSGames.BoardGame {
    
    [RequireComponent(typeof(ItemModel))]
    public class ItemController : InteractableController, IItem {
        
        ItemModel m_ItemModel;
        public ItemModel itemModel {
            get { return m_ItemModel; }
        }

        Item m_ItemData;
        public Item itemData {
            get {return m_ItemData;}
            set {m_ItemData = value;}
        }

        override protected void Awake(){
            m_ItemModel = GetComponent<ItemModel>();
        }



        public void Pickup(){

        }

        public void Drop(){

        }


    }
}