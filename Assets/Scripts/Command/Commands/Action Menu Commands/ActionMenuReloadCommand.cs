using UnityEngine;

namespace OSGames.BoardGame {

    public class ActionMenuReloadCommand : ActionMenuCommand {
        public ActionMenuReloadCommand(ActionMenuController actionMenu) : base(actionMenu)
        {

        }

        override public void Execute(){
            Debug.Log("Executed Action Menu Reload Command!");
        }

    }

}