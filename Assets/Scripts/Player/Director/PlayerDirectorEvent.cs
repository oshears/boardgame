using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Player;
using UnityEngine;

namespace OSGames.BoardGame{

    public class PlayerDirectorEvent : EventData<PlayerDirector> {

        public PlayerDirectorEvent(PlayerDirector sender) : base(sender) {

        }
    }

}