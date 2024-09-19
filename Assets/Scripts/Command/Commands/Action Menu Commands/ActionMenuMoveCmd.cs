using UnityEngine;
using OSGames.BoardGame.Generic;

namespace OSGames.BoardGame {

    public class ActionMenuMoveCmd : ActionMenuCommand {
        public ActionMenuMoveCmd(ActionMenuController actionMenu) : base(actionMenu)
        {

        }

        override public void Execute(){
            Debug.Log("Executed Action Menu Move Command!");

            m_ActionMenuController.RequestAction(RoomAction);
        }

    }

}