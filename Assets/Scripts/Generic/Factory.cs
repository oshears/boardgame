using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OSGames.BoardGame.Generic {

    // [[RequireComponent(typeof(Subscriber))]]
    // [[RequireComponent(typeof(Publisher))]]
    [Icon("Packages/com.osgames.boardgame/Assets/Icons/osgames_logo.png")]
    public abstract class Factory<T, U> : MonoBehaviour
    {

        public abstract U Make(T t);

    }
}