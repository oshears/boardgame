using System;
using UnityEngine;
using UnityEngine.AI;

using OSGames.BoardGame;
using OSGames.Utilities.AI;
using System.Collections;
using OSGames.BoardGame.Player;

namespace OSGames.BoardGame {
    public class PlayerDirectorSwitchNextPlayer : PlayerDirectorCommand {

        // PhaseEvent m_PhaseEvent;
        public PlayerDirectorSwitchNextPlayer(PlayerDirector playerDirector) : base(playerDirector){
            // m_PhaseEvent = phaseEvent;
        }

        override public void Execute(){

            // if current player turn less than number of players, go to next player

            // otherwise send a new player director event (prompting the phase director to go to the next phase)
            m_PlayerDirector.players[m_PlayerDirector.currentPlayerTurn].state = PlayerController.State.InactiveControls;
            m_PlayerDirector.currentPlayerTurn += 1;
            if (m_PlayerDirector.currentPlayerTurn > m_PlayerDirector.players.Count){
                m_PlayerDirector.currentPlayerTurn = 0;

                PlayerDirectorEvent directorEvent = new PlayerDirectorEvent(m_PlayerDirector);
                m_PlayerDirector.publisher.Publish(directorEvent);
            }
            else{
                PlayerController nextPlayer = m_PlayerDirector.players[m_PlayerDirector.currentPlayerTurn];
                nextPlayer.state = PlayerController.State.ActiveControls;
            }
            


        }
    }
}