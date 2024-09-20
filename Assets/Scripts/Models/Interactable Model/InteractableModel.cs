using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

using OSGames.BoardGame;

namespace OSGames.BoardGame.Interactables {

    public class InteractableModel : Model {

        [SerializeField] InteractableConfig m_InteractableConfig;

        InteractableModel m_NextInteractable;
        public InteractableModel NextInteractable { 
            get {return m_NextInteractable;}
            set {m_NextInteractable = value;}
        } 
        InteractableModel m_PrevInteractable;
        public InteractableModel PrevInteractable { 
            get {return m_PrevInteractable;}
            set {m_PrevInteractable = value;}
        } 

        [SerializeField] UnityEvent e_SetHighlight;
        [SerializeField] UnityEvent e_ClearHighlight;

        [SerializeField] Transform m_PlayerStandingPoint;
        public Transform PlayerStandingPoint {get {return m_PlayerStandingPoint;}}


        public virtual void SetHighlight(){
            e_SetHighlight.Invoke();
        }

        public virtual void ClearHighlight(){
            e_ClearHighlight.Invoke();
        }

        public InteractableType GetInteractableType(){
            return m_InteractableConfig.InteractableType;
        }

    }
}