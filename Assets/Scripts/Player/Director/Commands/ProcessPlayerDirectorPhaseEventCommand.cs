using System;
using UnityEngine;
using UnityEngine.AI;

using OSGames.BoardGame;
using OSGames.Utilities.AI;
using System.Collections;
using OSGames.BoardGame.Player;

namespace OSGames.BoardGame {
    public class PlayerDirectorProcessPhaseEventCommand : PlayerDirectorCommand {

        PhaseEvent m_PhaseEvent;
        public PlayerDirectorProcessPhaseEventCommand(PlayerDirector playerDirector, PhaseEvent phaseEvent) : base(playerDirector){
            m_PhaseEvent = phaseEvent;
        }

        override public void Execute(){

            if (m_PhaseEvent.eventType == PhaseEventType.StartPlayerPhase){
                // m_PlayerController.state = PlayerController.State.ActiveControls;

                PlayerController playerController = m_PlayerDirector.players[0];

                playerController.StartTurn();

                //@TODO: Activate first player controls
                playerController.state = PlayerController.State.ActiveControls;
                // PlayerDirectorEvent directorEvent = new PlayerDirectorEvent(playerDirector);
                // m_PlayerDirector.publisher.Publish(directorEvent);
            }
            else{
                m_PlayerDirector.players[0].state = PlayerController.State.InactiveControls;
            }

        }

    }

}