using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OSGames.BoardGame.Generic {

    [Icon("Packages/com.osgames.boardgame/Assets/Icons/osgames_logo.png")]
    public abstract class Model : MonoBehaviour
    {

        #if UNITY_EDITOR
        protected virtual void OnDrawGizmosSelected() {

        }
        #endif

    }
}