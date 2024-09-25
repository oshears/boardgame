using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

using OSGames.BoardGame;
using OSGames.BoardGame.Generic;
using UnityEditor.EditorTools;

namespace OSGames.BoardGame.Interactables {

    public class InteractableModel : Model, ICycleableInteractable {

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

        [SerializeField] UnityEvent e_Use;
        [SerializeField] UnityEvent e_FinishUse;

        [Tooltip("Optional: location the player will stand when interacting")]
        [SerializeField] Transform m_PlayerStandingPoint;
        public Transform PlayerStandingPoint {
            get {return m_PlayerStandingPoint ? m_PlayerStandingPoint : transform;}
        }

        [Tooltip("Optional: location the player will stand when scanning the room")]
        [SerializeField] Transform m_PlayerLookPoint;
        public Transform PlayerLookPoint { 
            get {return m_PlayerLookPoint ? m_PlayerLookPoint : transform;} 
        }



        public virtual void SetHighlight(){
            e_SetHighlight.Invoke();
        }

        public virtual void ClearHighlight(){
            e_ClearHighlight.Invoke();
        }

        public InteractableType GetInteractableType(){
            return m_InteractableConfig.InteractableType;
        }

        public IInteractable GetNext(){
            return m_NextInteractable;
        }

        public IInteractable GetPrev(){
            return m_PrevInteractable;
        }

        public virtual void Use(){
            e_Use.Invoke();
        }

        public virtual void FinishUse(){
            e_FinishUse.Invoke();
        }

    }
}