
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Interactables;
using OSGames.BoardGame.Player;

namespace OSGames.BoardGame {

    // [CreateAssetMenu(fileName = "Command Factory", menuName = "Board Game/Command Factory", order = 0)]
    // public class CommandFactory
    // {
        
    //     // public virtual CommandFactory GetCommand()
    //     // {

    //     // }
    // }

    public class RoomCommandFactory : Factory<RoomCommandProduct, RoomCommand>
    {
        public override RoomCommand Make(RoomCommandProduct product){

            if (product.RoomAction.ActionType == ActionType.Move){
                return new RoomMoveCommand(product.RoomController, product.RoomAction);
            }
            else if (product.RoomAction.ActionType == ActionType.Use && product.RoomController.RoomModel.TargetedInteractable){
                if (product.RoomController.RoomModel.TargetedInteractable.GetInteractableType() == InteractableType.Doorway){
                    // return new RoomMoveCommand(product.RoomController, product.RoomAction);
                    return new RoomMoveCommand(product.RoomController, product.RoomAction);
                }
                else {
                    return new RoomUseCommand(product.RoomController, product.RoomAction);
                }
            }
            else if (product.RoomAction.ActionType == ActionType.SetTarget){
                return new RoomSetTargetCommand(product.RoomController, product.RoomAction);
            }
            else if (product.RoomAction.ActionType == ActionType.CycleLeft){
                return new RoomCycleInteractableLeftCommand(product.RoomController, product.RoomAction);
            }
            else if (product.RoomAction.ActionType == ActionType.CycleRight){
                return new RoomCycleInteractableRightCommand(product.RoomController, product.RoomAction);
            }
            else{
                return new RoomCommand(product.RoomController, product.RoomAction);
            }
        }

    }

    public class RoomCommandProduct {
        public RoomController RoomController;
        public RoomAction RoomAction;
        public PlayerController PlayerController;
        public RoomCommandProduct(RoomController roomController, RoomAction roomAction)
        {
            RoomController = roomController;
            RoomAction = roomAction;
        }

        public RoomCommandProduct(RoomController roomController, RoomAction roomAction, PlayerController playerController)
        {
            RoomController = roomController;
            RoomAction = roomAction;
            PlayerController = playerController;
        }
    }
}