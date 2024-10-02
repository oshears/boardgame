using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using OSGames.BoardGame.Generic;

namespace OSGames.BoardGame.Generic {

    public class Subscriber<T>
    {
        [SerializeField] private IPublisher<T> m_PublisherToObserve;
        public IPublisher<T> PublisherToObserve {
            get { return m_PublisherToObserve; }
            set {
                Unsubscribe();
                SubscribeTo(value);
            }
        }

        public event Action<T> PublisherAction;

        protected virtual void OnThingHappened(T t)
        {
            // any logic that responds to event goes here
            Debug.Log($"Subscriber responds given: {t}");

            PublisherAction?.Invoke(t);
        }

        public void SubscribeTo(IPublisher<T> publisherToObserve){

            m_PublisherToObserve = publisherToObserve; 

            if (m_PublisherToObserve != null)
            {
                m_PublisherToObserve.AddListener(OnThingHappened);
            }
        }
        public void Unsubscribe(){
            if (m_PublisherToObserve != null)
            {
                m_PublisherToObserve.RemoveListener(OnThingHappened);
            }
        }
    }
}