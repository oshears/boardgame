using System;
using UnityEngine;
using UnityEngine.AI;

using OSGames.BoardGame;
using OSGames.Utilities.AI;
using System.Collections;
using OSGames.BoardGame.Player;

namespace OSGames.BoardGame {
    public class PlayerDirectorProcessPlayerEventCommand : PlayerDirectorCommand {

        PlayerEvent m_PlayerEvent;
        public PlayerDirectorProcessPlayerEventCommand(PlayerDirector playerDirector, PlayerEvent playerEvent) : base(playerDirector){
            m_PlayerEvent = playerEvent;
        }

        override public void Execute(){
            m_PlayerDirector.players[0].state = PlayerController.State.InactiveControls;

            PlayerDirectorEvent directorEvent = new PlayerDirectorEvent(m_PlayerDirector);
            m_PlayerDirector.publisher.Publish(directorEvent);

            // if (m_PlayerEvent.eventType == PlayerEventType.ExecuteAction){
            //     // m_PlayerController.state = PlayerController.State.ActiveControls;
                
            //     //@TODO: Activate first player controls
            //     m_PlayerDirector.players[0].state = PlayerController.State.ActiveControls;
            //     // PlayerDirectorEvent directorEvent = new PlayerDirectorEvent(playerDirector);
            //     // m_PlayerDirector.publisher.Publish(directorEvent);
            // }
            // else{
            //     m_PlayerDirector.players[0].state = PlayerController.State.InactiveControls;
            // }

        }

    }

}