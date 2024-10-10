using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Player;
using UnityEngine;

namespace OSGames.BoardGame{

    public enum PlayerEventType{
        ExecuteAction,
        Pass,
    }

    public class PlayerEvent : EventData<PlayerController> {
        PlayerEventType m_EventType;
        public PlayerEventType eventType{
            get { return m_EventType; }
        }
        public PlayerEvent(PlayerController sender, PlayerEventType eventType) : base(sender) {
            m_EventType = eventType;
        }
    }

}