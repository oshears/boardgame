using UnityEngine;
using UnityEngine.UI;
using TMPro;

using OSGames.BoardGame.Input;
using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Player;

namespace OSGames.BoardGame {
    public class PlayerCommandFactory : Factory<PlayerCommandProduct, PlayerCommand>
    {
        
        public override PlayerCommand Make(PlayerCommandProduct product){
            if (product.Type == InputType.Confirm){
                if (product.PlayerController.PlayerModel.TargetInteractable != null) {
                    return new PlayerInteractCommand(product.PlayerController, product.PlayerController.PlayerModel.TargetInteractable);
                }
                else {
                    return new PlayerCommand(product.PlayerController);
                }
            }
            else if (product.Type == InputType.CycleRight || product.Type == InputType.CycleLeft ){
                // Transform target = ((SetTargetAction) product.RoomAction).NewTarget;
                return new PlayerSetTargetCommand(product.PlayerController, product.Type == InputType.CycleRight);
            }
            else if (product.Type == InputType.ToggleMenu){
                return new PlayerToggleMenuCommand(product.PlayerController);
            }
            else if (product.Type == InputType.Back){
                return new PlayerBackCommand(product.PlayerController);
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