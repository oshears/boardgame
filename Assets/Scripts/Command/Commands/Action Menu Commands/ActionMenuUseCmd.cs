using UnityEngine;

namespace BoardGame {

    public class ActionMenuUseCmd : ActionMenuCmd {
        public ActionMenuUseCmd(ActionMenuController actionMenu) : base(actionMenu)
        {
            
        }

        override public void Execute(){
            Debug.Log("Executed Action Menu Move Command!");
        }
    }

}