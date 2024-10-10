using OSGames.BoardGame;
using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Player;

namespace OSGames.BoardGame {
    public class PlayerDirectorCommand : Command {

        protected PlayerDirector m_PlayerDirector;

        public PlayerDirectorCommand(PlayerDirector PlayerDirector) {
            m_PlayerDirector = PlayerDirector;
        }

    }
}