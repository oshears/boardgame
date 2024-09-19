using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OSGames.BoardGame {

    // [[RequireComponent(typeof(Subscriber))]]
    // [[RequireComponent(typeof(Publisher))]]
    public abstract class Factory<T, U> : MonoBehaviour
    {

        public abstract U Make(T t);

    }
}