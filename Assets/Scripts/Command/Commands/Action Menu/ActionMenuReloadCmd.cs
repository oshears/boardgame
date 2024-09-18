using UnityEngine;

namespace BoardGame {

    public class ActionMenuReloadCmd : ActionMenuCmd {
        public ActionMenuReloadCmd(ActionMenuController actionMenu) : base(actionMenu)
        {

        }

        override public void Execute(){
            Debug.Log("Executed Action Menu Reload Command!");
        }

    }

}