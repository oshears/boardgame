using UnityEngine;

namespace BoardGame {

    public class ActionMenuMoveCmd : ActionMenuCmd {
        public ActionMenuMoveCmd(ActionMenuController actionMenu) : base(actionMenu)
        {

        }

        override public void Execute(){
            Debug.Log("Executed Action Menu Move Command!");
        }

    }

}