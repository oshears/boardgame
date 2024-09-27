using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

using OSGames.BoardGame;
using OSGames.BoardGame.Generic;


namespace OSGames.BoardGame.Interactables {

    public class InteractableModel : Model, ICycleableInteractable {

        [SerializeField] InteractableConfig m_InteractableConfig;

        ICycleableInteractable m_NextInteractable;
        public ICycleableInteractable NextInteractable { 
            get {return m_NextInteractable;}
            set {m_NextInteractable = value;}
        } 
        ICycleableInteractable m_PrevInteractable;
        public ICycleableInteractable PrevInteractable { 
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

        public virtual void Use(){
            e_Use.Invoke();
        }

        public virtual void FinishUse(){
            e_FinishUse.Invoke();
        }

        public Transform GetTransform(){
            return transform;
        }

        public ICycleableInteractable GetNext()
        {
            return m_NextInteractable;
        }

        public ICycleableInteractable GetPrev()
        {
            return m_PrevInteractable;
        }

        public Transform GetLookPosition()
        {
            return PlayerLookPoint;
        }

        public Transform GetStandPosition()
        {
            return PlayerStandingPoint;
        }

        public void SetNext(ICycleableInteractable next)
        {
            m_NextInteractable = next;
        }

        public void SetPrev(ICycleableInteractable prev)
        {
            m_PrevInteractable = prev;
        }
    }
}