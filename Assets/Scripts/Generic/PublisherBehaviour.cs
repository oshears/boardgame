using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OSGames.BoardGame.Generic {

    [Icon("Packages/com.osgames.boardgame/Assets/Icons/osgames_logo.png")]
    public abstract class PublisherBehaviour<T> : MonoBehaviour, IPublisher<T>
    {

        Publisher<T> m_Publisher;

        void Awake(){
            m_Publisher = new Publisher<T>();
        }

        public virtual void Publish(T t)
        {
            m_Publisher.Publish(t);
        }

        public void AddListener(Action<T> func){
            m_Publisher.AddListener(func);
        }

        public void RemoveListener(Action<T> func){
            m_Publisher.RemoveListener(func);
        }

    }

    
}