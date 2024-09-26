using UnityEngine;
using UnityEngine.UI;
using TMPro;

using OSGames.BoardGame.Input;
using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Player;

namespace OSGames.BoardGame {
    public class PlayerCommandFactory : Factory<PlayerCommandProduct, PlayerCommand>
    {
        // public override PlayerCommand Make(PlayerCommandProduct product){

        //     if (product.RoomAction.ActionType == ActionType.Move){
        //         MovementAction moveAction = (MovementAction) product.RoomAction;
        //         return new PlayerMoveCommand(product.PlayerController, moveAction.Destination, moveAction.DestinationRoomPublisher);
        //     }
        //     else if (product.RoomAction.ActionType == ActionType.MoveAndUse){
        //         Transform destination = ((MoveAndUseAction) product.RoomAction).Destination;
        //         return new PlayerMoveAndUseCommand(product.PlayerController, destination);
        //     }
        //     else if (
        //         product.RoomAction.ActionType == ActionType.SetTarget
        //         || product.RoomAction.ActionType == ActionType.CycleRight
        //         || product.RoomAction.ActionType == ActionType.CycleLeft
        //         ){
        //         Transform target = ((SetTargetAction) product.RoomAction).NewTarget;
        //         return new PlayerSetTargetCommand(product.PlayerController, target);
        //     }
        //     else if (product.RoomAction.ActionType == ActionType.ToggleMenu){
        //         return new PlayerToggleCameraCommand(product.PlayerController);
        //     }
        //     else{
        //         return new PlayerCommand(product.PlayerController, product.RoomAction);
        //     }
        // }

        public override PlayerCommand Make(PlayerCommandProduct product){
            if (product.Type == InputType.Confirm){
                if (product.PlayerController.PlayerModel.TargetInteractable.GetTransform().TryGetComponent(out IMovementIndicator indicator)){
                    return new PlayerMoveCommand(product.PlayerController, indicator);
                }
                else{
                    return new PlayerMoveAndUseCommand(product.PlayerController);
                }
            }
            else if (product.Type == InputType.CycleRight || product.Type == InputType.CycleLeft ){
                // Transform target = ((SetTargetAction) product.RoomAction).NewTarget;
                return new PlayerSetTargetCommand(product.PlayerController, product.Type == InputType.CycleRight);
            }
            else if (product.Type == InputType.ToggleMenu){
                return new PlayerToggleMenuCommand(product.PlayerController);
            }
            else{
                return new PlayerCommand(product.PlayerController);
            }
        }

    }

    public class PlayerCommandProduct {
        public PlayerController PlayerController;
        public InputType Type;
        public PlayerCommandProduct(PlayerController playerController, InputType type)
        {
            PlayerController = playerController;
            Type = type;
        }
    }
}