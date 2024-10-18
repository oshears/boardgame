using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

using OSGames.BoardGame;
using OSGames.BoardGame.Generic;
using System;
using OSGames.BoardGame.Actions;

namespace OSGames.BoardGame.Interactables {


    [RequireComponent(typeof(InteractableModel))]
    public class InteractableController : Controller, IPublisher<InteractableEvent>, IScheduler
    {

        Publisher<InteractableEvent> m_Publisher;

        InteractableModel m_InteractableModel;
        public InteractableModel interactableModel {
            get { return m_InteractableModel;}
        }

        virtual protected void Awake(){
            m_Publisher = new Publisher<InteractableEvent>();
            m_InteractableModel = GetComponent<InteractableModel>();
            m_InteractableModel.e_FinishUse.AddListener(OnFinishUse);
        }

        virtual protected void OnEnable(){
            m_InteractableModel.e_FinishUse.AddListener(OnFinishUse);
        }

        virtual protected void OnDisable(){
            m_InteractableModel.e_FinishUse.RemoveListener(OnFinishUse);
        }

        public void Publish(InteractableEvent message)
        {
            m_Publisher.Publish(message);
        }

        public void AddListener(Action<InteractableEvent> func)
        {
            m_Publisher.AddListener(func);
        }

        public void RemoveListener(Action<InteractableEvent> func)
        {
            m_Publisher.RemoveListener(func);
        }

        public void ExecuteCommand(ICommand cmd)
        {
            cmd.Execute();
        }

        public ICommand UndoCommand()
        {
            throw new NotImplementedException();
        }

        protected void OnFinishUse(){
            Debug.Log("Finish use of interactable!");
            InteractableEvent interactableEvent = new InteractableEvent(gameObject, InteractableEventType.InteractFinish);
            m_Publisher.Publish(interactableEvent);
        }
    }
}