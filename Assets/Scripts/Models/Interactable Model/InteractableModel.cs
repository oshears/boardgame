using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

using OSGames.BoardGame;
using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Actions;


namespace OSGames.BoardGame.Interactables {

    public class InteractableModel : Model, IActionHolder {

        [SerializeField]
        protected InteractableConfig m_InteractableConfig;
        public InteractableConfig interactableConfig {
            get {return m_InteractableConfig;}
        }

        [SerializeField] UnityEvent e_SetHighlight;
        [SerializeField] UnityEvent e_ClearHighlight;

        [SerializeField] public UnityEvent e_Use = new UnityEvent();
        [SerializeField] public UnityEvent e_FinishUse = new UnityEvent();

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

        public Transform GetLookPosition()
        {
            return PlayerLookPoint;
        }

        public Transform GetStandPosition()
        {
            return PlayerStandingPoint;
        }

        public PlayerAction GetPlayerAction(){
            return m_InteractableConfig.playerAction;
        }

        public void SetPlayerAction(PlayerAction action)
        {
            throw new System.NotImplementedException();
        }
    }
}