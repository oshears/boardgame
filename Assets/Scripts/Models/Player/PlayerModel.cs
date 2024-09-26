using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;
// using Cinemachine;

using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Interactables;

namespace OSGames.BoardGame.Player {

    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]
    public class PlayerModel : Model, IPlayer, IInteractable {

        NavMeshAgent m_Agent;
        public NavMeshAgent Agent {get { return m_Agent;} }
        Animator m_Animator;
        public Animator Animator { get { return m_Animator; }}

        // public PlayerMenuModel m_PlayerMenu;

        
        [SerializeField]
        protected RoomModel m_CurrentRoom;
        public RoomModel CurrentRoom {
            get { return m_CurrentRoom; }
            set { m_CurrentRoom = value; }
        }

        [Tooltip("The interactable currently being viewed by the player")]
        [SerializeField] ICycleableInteractable m_CurrentTarget;

        public UnityEvent e_RotatePlayer;

        public ICycleableInteractable TargetInteractable {
            get { return m_CurrentTarget;} 
            set {m_CurrentTarget = value;}    
        }

        protected void Awake(){
            m_Agent = GetComponent<NavMeshAgent>();
            m_Animator = GetComponent<Animator>();
        }

        public virtual void SetMenuCamera(bool menuCamera){
            
        }

        public void ExecuteOnNavMeshArrival(Action method){
            StartCoroutine(WaitNavMeshArrive(method));
        }

        IEnumerator WaitNavMeshArrive(Action method){
            bool arrived = false;
            while (!arrived){
                yield return new WaitForSeconds(0.1f);
                if (!m_Agent.pathPending)
                {
                    if (m_Agent.remainingDistance <= m_Agent.stoppingDistance)
                    {
                        if (!m_Agent.hasPath || m_Agent.velocity.sqrMagnitude == 0f)
                        {
                            arrived = true;
                        }
                    }
                }
            }

            method();
            // Execute Typing Animation
            // m_Animator.SetBool("Typing",true);
        }

        public void ResetAnimatorAfter(float time){
            StartCoroutine(WaitThenExecute(time,ResetAnimator));
        }

        IEnumerator WaitThenExecute(float time, Action method){
            yield return new WaitForSeconds(time);
            method();
        }

        void ResetAnimator(){
            m_Animator.SetBool("Typing",false);
            m_Animator.SetBool("Rotating",false);
        }

        public void Use(){

        }

        public void FinishUse(){

        }

        public void SetHighlight(){

        }

        public void ClearHighlight(){
            
        }

        public Transform GetLookPosition(){
            return transform;
        }

        public Transform GetStandPosition(){
            return transform;
        }

        public Transform GetTransform(){
            return transform;
        }

    }

}