using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OSGames.BoardGame.Generic {

    [Icon("Packages/com.osgames.boardgame/Assets/Icons/osgames_logo.png")]

    public abstract class SubscriberBehaviour<T> : MonoBehaviour, ISubscriber<T>
    {
        [SerializeField] private List<PublisherBehaviour<T>> m_InitialPublishersToObserve;

        Subscriber<T> m_Subscriber;

        public List<IPublisher<T>> publishersToObserve {
            get { return m_Subscriber.publishersToObserve; }
        }

        /// <summary>
        /// C# Action indicating the publisher sent some event data
        /// </summary>
        public event Action<T> PublisherAction;

        void Awake(){
           
            m_Subscriber = new Subscriber<T>();

            if (m_InitialPublishersToObserve != null){
                // m_Subscriber.SubscribeTo(m_InitialPublishersToObserve);
                m_InitialPublishersToObserve.ForEach(publisher => m_Subscriber.SubscribeTo(publisher));
            }
            else{
                 m_InitialPublishersToObserve = new List<PublisherBehaviour<T>>();
            }

            m_Subscriber.PublisherAction += OnThingHappened;
        }

        protected virtual void OnThingHappened(T t)
        {
            // any logic that responds to event goes here
            Debug.Log($"Subscriber responds given: {t}");

            PublisherAction?.Invoke(t);
        }

        public void SubscribeTo(IPublisher<T> publisherToObserve){
            m_Subscriber.SubscribeTo(publisherToObserve);
        }

        /// <summary>
        /// If there was something the subcriber subscribed to, then remove its listener 
        /// </summary>
        public void Unsubscribe(){
            m_Subscriber.Unsubscribe();
        }

        public void UnsubscribeFrom(IPublisher<T> publisher)
        {
            m_Subscriber.UnsubscribFrom(publisher);
        }
    }
}