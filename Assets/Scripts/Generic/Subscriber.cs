using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using OSGames.BoardGame.Generic;

namespace OSGames.BoardGame {

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

        public Action<T> PublisherAction;

        protected virtual void OnThingHappened(T t)
        {
            // any logic that responds to event goes here
            Debug.Log($"Subscriber responds given: {t}");

            PublisherAction?.Invoke(t);
        }

        // protected virtual void Awake()
        // {
        //     if (m_PublisherToObserve != null)
        //     {
        //         m_PublisherToObserve.GetAction() += OnThingHappened;
        //     }
        // }

        // protected virtual void OnDestroy()
        // {
        //     if (m_PublisherToObserve != null)
        //     {
        //         m_PublisherToObserve.GetAction() -= OnThingHappened;
        //     }
        // }

        public void SubscribeTo(IPublisher<T> publisherToObserve){
            Unsubscribe();

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