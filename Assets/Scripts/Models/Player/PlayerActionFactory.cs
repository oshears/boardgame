using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OSGames.BoardGame;
using OSGames.BoardGame.Generic;

namespace OSGames.BoardGame.Player {

    public class PlayerActionFactory : Factory<PlayerActionProduct, PlayerAction> {

        public PlayerActionFactory() {

        }

        public override PlayerAction Make(PlayerActionProduct product){
            return new PlayerAction(product.PlayerController);
        }

    }

    public class PlayerActionProduct {
        public PlayerController PlayerController;

        public PlayerActionProduct(PlayerController playerController){
            PlayerController = playerController;
        }

    }

}