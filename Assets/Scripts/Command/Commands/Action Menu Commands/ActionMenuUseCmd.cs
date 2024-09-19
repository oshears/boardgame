using UnityEngine;

namespace OSGames.BoardGame {

    public class ActionMenuUseCmd : ActionMenuCommand {
        public ActionMenuUseCmd(ActionMenuController actionMenu) : base(actionMenu)
        {
            
        }

        override public void Execute(){
            Debug.Log("Executed Action Menu Move Command!");
        }
    }

}