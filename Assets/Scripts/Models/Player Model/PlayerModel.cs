using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;
// using Cinemachine;

using OSGames.BoardGame.Interactables;

namespace OSGames.BoardGame {

    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]
    public class PlayerModel : Model {

        NavMeshAgent m_Agent;
        public NavMeshAgent Agent {get { return m_Agent;} }
        Animator m_Animator;
        public Animator Animator { get { return m_Animator; }}

        [Tooltip("The interactable currently being viewed by the player")]
        [SerializeField] InteractableController m_CurrentTarget;

        public UnityEvent e_RotatePlayer;

        public InteractableController TargetInteractable {
            get { return m_CurrentTarget;} 
            set {m_CurrentTarget = value;}    
        }

        protected void Awake(){
            m_Agent = GetComponent<NavMeshAgent>();
            m_Animator = GetComponent<Animator>();
        }

        public virtual void ToggleCamera(){
            
        }

    }

}