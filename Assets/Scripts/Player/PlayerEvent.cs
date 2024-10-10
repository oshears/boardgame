using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Player;
using UnityEngine;

namespace OSGames.BoardGame{

    // public enum PlayerEvent {
    //     PlayerPause,
    // }

    [Icon("Packages/com.osgames.boardgame/Assets/Icons/osgames_logo.png")]
    public class PlayerEvent : EventData<PlayerController> {

        // PhaseEventType m_EventType;
        // public PhaseEventType eventType {
        //     get {return m_EventType;}
        // }        
        public PlayerEvent(PlayerController sender) : base(sender) {
            // m_EventType = eventType;
        }
    }

}