using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OSGames.BoardGame.Generic {

    public class Subscriber<T>
    {
        List<IPublisher<T>> m_PublishersToObserve;
        public List<IPublisher<T>> publishersToObserve {
            get { return m_PublishersToObserve; }
            // set {
            //     SubscribeTo(value);
            // }
        }

        /// <summary>
        /// C# Action indicating the publisher sent some event data
        /// </summary>
        public event Action<T> PublisherAction;

        public Subscriber(){
            m_PublishersToObserve = new List<IPublisher<T>>();
        }

        protected virtual void OnThingHappened(T t)
        {
            // any logic that responds to event goes here
            PublisherAction?.Invoke(t);
        }

        public void SubscribeTo(IPublisher<T> publisherToObserve){
            m_PublishersToObserve.Add(publisherToObserve);
            publisherToObserve.AddListener(OnThingHappened);
        }

        public void SubscribeTo(List<IPublisher<T>> publishersToObserve){
            publishersToObserve.ForEach(publisher => SubscribeTo(publisher) );
        }

        /// <summary>
        /// If there was something the subcriber subscribed to, then remove its listener 
        /// </summary>
        public void Unsubscribe(){
            foreach (IPublisher<T> publisher in m_PublishersToObserve){
                publisher.RemoveListener(OnThingHappened);
            }
            m_PublishersToObserve.Clear();
        }

        public void UnsubscribFrom(IPublisher<T> publisher){
            if (publishersToObserve.Contains(publisher)){
                publisher.RemoveListener(OnThingHappened);
                publishersToObserve.Remove(publisher);
            }

        }
    }
}