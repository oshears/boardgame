using UnityEngine;

namespace OSGames.BoardGame {

    public class ActionMenuReloadCmd : ActionMenuCommand {
        public ActionMenuReloadCmd(ActionMenuController actionMenu) : base(actionMenu)
        {

        }

        override public void Execute(){
            Debug.Log("Executed Action Menu Reload Command!");
        }

    }

}