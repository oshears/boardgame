using OSGames.BoardGame.Generic;
using UnityEngine;

namespace OSGames.BoardGame{

    public enum PhaseEventType {
        StartPlayerPhase,
        StartEventPhase,
    }

    [Icon("Packages/com.osgames.boardgame/Assets/Icons/osgames_logo.png")]
    public class PhaseEvent : EventData<PhaseDirector> {

        PhaseEventType m_EventType;
        public PhaseEventType eventType {
            get {return m_EventType;}
        }        
        public PhaseEvent(PhaseDirector sender, PhaseEventType eventType) : base(sender) {
            m_EventType = eventType;
        }
    }

}