using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BoardGame {

    public abstract class Controller<T> : MonoBehaviour
    {

        Subscriber<T> m_Subscriber;
        public Subscriber<T> Subscriber {
            get { return m_Subscriber;}
        }
        // [SerializeField] Publisher<T> m_Publisher;

        

        protected virtual void Awake()
        {
            m_Subscriber = GetComponent<Subscriber<T>>();

            if (m_Subscriber != null)
            {
                m_Subscriber.PublisherAction += OnPublisherAction;
            }
        }

        protected virtual void OnDestroy()
        {
            if (m_Subscriber != null)
            {
                m_Subscriber.PublisherAction -= OnPublisherAction;
            }
        }

        public abstract void OnPublisherAction(T t);


    }
}