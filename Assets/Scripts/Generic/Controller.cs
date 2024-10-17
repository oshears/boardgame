using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OSGames.BoardGame.Generic {

    [Icon("Packages/com.osgames.boardgame/Assets/Icons/osgames_logo.png")]
    public abstract class Controller : MonoBehaviour
    {

        [SerializeField] bool m_GizmosEnabled;

        public bool gizmosEnabled {
            get { return m_GizmosEnabled;}
            set {m_GizmosEnabled = value;}
        }

        #if UNITY_EDITOR
        protected virtual void OnDrawGizmos() {
            
            
        }
        #endif
        

    }
}