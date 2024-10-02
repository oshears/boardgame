using UnityEngine;

namespace OSGames.BoardGame.Actions {

    public interface IActionHolder {
        public PlayerAction GetPlayerAction();
        public void SetPlayerAction(PlayerAction action);
    }
}