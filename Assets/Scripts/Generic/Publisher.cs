using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OSGames.BoardGame.Generic {

    public class Publisher<T>
    {
        public event Action<T> ThingHappened;
        public virtual void Publish(T t)
        {
            // ThingHappened.Invoke(t);
            // this will send errors if no one is subscribed to the event
            ThingHappened(t);
        }

        public void AddListener(Action<T> func){
            ThingHappened += func;
        }

        public void RemoveListener(Action<T> func){
            ThingHappened -= func;
        }

    }

    
}