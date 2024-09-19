using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

namespace OSGames.BoardGame {

    public class InteractableModel : Model {

        [SerializeField] InteractableModel m_NextInteractable;
        public InteractableModel NextInteractable { get {return m_NextInteractable;}} 
        [SerializeField] InteractableModel m_PrevInteractable;
        public InteractableModel PrevInteractable { get {return m_PrevInteractable;}} 


        [SerializeField] UnityEvent e_SetHighlight;
        [SerializeField] UnityEvent e_ClearHighlight;

        public void SetHighlight(){
            e_SetHighlight.Invoke();
        }

        public void ClearHighlight(){
            e_ClearHighlight.Invoke();
        }

    }
}