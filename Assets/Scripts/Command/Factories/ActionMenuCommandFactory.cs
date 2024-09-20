using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OSGames.BoardGame.Generic;

namespace OSGames.BoardGame {
    public class ActionMenuCommandFactory : Factory<ActionMenuCommandProduct, ActionMenuCommand>
    {
        public override ActionMenuCommand Make(ActionMenuCommandProduct product){
            if (product.RoomAction.ActionType == ActionType.ToggleMenu){

                // bool active = ((ToggleMenu) product.RoomAction).ToggleSetting;
                ((ToggleMenu) product.RoomAction).ToggleSetting = product.ActionMenuController.ActionMenu.MenuActive;
                return new ActionMenuToggleCommand(product.ActionMenuController, ((ToggleMenu) product.RoomAction).ToggleSetting);
            }
            else if (product.RoomAction.ActionType == ActionType.Move){
                return new ActionMenuMoveCommand(product.ActionMenuController, product.RoomAction); 
            }
            else{
                return new ActionMenuCommand(product.ActionMenuController, product.RoomAction);
            }
        }
    }

    public class ActionMenuCommandProduct {
        public ActionMenuController ActionMenuController;
        public RoomAction RoomAction;
        public ActionMenuCommandProduct(ActionMenuController actionMenuController, RoomAction roomAction)
        {
            ActionMenuController = actionMenuController;
            RoomAction = roomAction;
        }
    }
}