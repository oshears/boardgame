using OSGames.BoardGame;
using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Player;

namespace OSGames.BoardGame {
    public class StartPhaseCommand : Command {
        
        PhaseDirector m_PhaseDirector;

        public StartPhaseCommand(PhaseDirector phaseDirector) {
            m_PhaseDirector = phaseDirector;

        }

        override public void Execute(){
            if (m_PhaseDirector.state == PhaseState.PlayerPhase ) {
                m_PhaseDirector.state = PhaseState.EventPhase;
                PhaseEvent phaseEvent = new PhaseEvent(m_PhaseDirector, PhaseEventType.StartEventPhase);
                m_PhaseDirector.publisher.Publish(phaseEvent);
            }
            else {
                m_PhaseDirector.state = PhaseState.PlayerPhase;
                PhaseEvent phaseEvent = new PhaseEvent(m_PhaseDirector, PhaseEventType.StartPlayerPhase);
                m_PhaseDirector.publisher.Publish(phaseEvent);
            }
        }
    }
}