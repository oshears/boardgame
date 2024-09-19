using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BoardGame {

    public abstract class Publisher<T> : MonoBehaviour, IPublisher<T> 
    {
        public event Action<T> ThingHappened;
        public virtual void Publish(T t)
        {
            // ThingHappened.Invoke(t);
            // this will send errors if no one is subscribed to the event
            ThingHappened(t);
        }

    }
}