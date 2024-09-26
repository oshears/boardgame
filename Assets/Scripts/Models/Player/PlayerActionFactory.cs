using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OSGames.BoardGame;
using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Actions;

namespace OSGames.BoardGame.Player {

    public class PlayerActionFactory : Factory<PlayerActionProduct, PlayerActionCommand> {

        public PlayerActionFactory() {

        }

        public override PlayerActionCommand Make(PlayerActionProduct product){
            return new PlayerActionCommand(product.PlayerController);
        }

    }

    public class PlayerActionProduct {
        public PlayerController PlayerController;

        public PlayerAction Action;

        public PlayerActionProduct(PlayerController playerController, PlayerAction action){
            PlayerController = playerController;
            Action = action;
        }

    }

}