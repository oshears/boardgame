using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BoardGame {

    public abstract class Subscriber<T> : MonoBehaviour
    {
        [SerializeField] private Publisher<T> m_PublisherToObserve;
        public Publisher<T> PublisherToObserve {
            get {return m_PublisherToObserve;}
        }

        public Action<T> PublisherAction;

        protected virtual void OnThingHappened(T t)
        {
            // any logic that responds to event goes here
            Debug.Log($"Subscriber responds given: {t}");

            PublisherAction?.Invoke(t);
        }

        protected virtual void Awake()
        {
            if (m_PublisherToObserve != null)
            {
                m_PublisherToObserve.ThingHappened += OnThingHappened;
            }
        }

        protected virtual void OnDestroy()
        {
            if (m_PublisherToObserve != null)
            {
                m_PublisherToObserve.ThingHappened -= OnThingHappened;
            }
        }
    }
}