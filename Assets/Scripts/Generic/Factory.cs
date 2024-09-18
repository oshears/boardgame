using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BoardGame {

    // [[RequireComponent(typeof(Subscriber))]]
    // [[RequireComponent(typeof(Publisher))]]
    public abstract class Factory<T> : MonoBehaviour
    {

        public abstract void Make(T t);

    }
}