
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OSGames.BoardGame.Generic;

namespace OSGames.BoardGame {
    public class PlayerCommandFactory : Factory<PlayerCommandProduct, PlayerCommand>
    {
        public override PlayerCommand Make(PlayerCommandProduct product){

            if (product.RoomAction.ActionType == ActionType.Move){
                Transform destination = ((MovementAction) product.RoomAction).Destination;
                return new PlayerMoveCommand(product.PlayerController, destination);
            }
            else if (product.RoomAction.ActionType == ActionType.SetTarget){
                Transform target = ((SetTargetAction) product.RoomAction).NewTarget;
                return new PlayerSetTargetCommand(product.PlayerController, target);
            }
            else{
                return new PlayerCommand(product.PlayerController, product.RoomAction);
            }
        }

    }

    public class PlayerCommandProduct {
        public PlayerController PlayerController;
        public RoomAction RoomAction;
        public PlayerCommandProduct(PlayerController playerController, RoomAction roomAction)
        {
            PlayerController = playerController;
            RoomAction = roomAction;
        }
    }
}