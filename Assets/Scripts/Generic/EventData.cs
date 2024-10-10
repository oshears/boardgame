using UnityEngine;

namespace OSGames.BoardGame.Generic {

    [Icon("Packages/com.osgames.boardgame/Assets/Icons/osgames_logo.png")]
    public abstract class EventData<T> {

        public T m_Sender;
        public T sender {
            get {return m_Sender;}
        }

        public EventData(T sender){
            this.m_Sender = sender;
        }
    }

}