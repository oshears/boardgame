using System;
using UnityEngine;
using UnityEngine.AI;

using OSGames.BoardGame;
using OSGames.Utilities.AI;
using System.Collections;

namespace OSGames.BoardGame.Player {
    public class ProcessPlayerPhaseEventCommand : PlayerCommand {

        PhaseEvent m_PhaseEvent;
        public ProcessPlayerPhaseEventCommand(PlayerController playerController, PhaseEvent phaseEvent) : base(playerController){
            m_PhaseEvent = phaseEvent;
        }

        override public void Execute(){

            if (m_PhaseEvent.eventType == PhaseEventType.StartPlayerPhase){
                m_PlayerController.state = PlayerController.State.ActiveControls;
            }
            else{
                m_PlayerController.state = PlayerController.State.InactiveControls;
            }

        }

    }

}