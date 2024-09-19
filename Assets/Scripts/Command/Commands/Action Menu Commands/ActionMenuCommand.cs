using UnityEngine;
using OSGames.BoardGame.Generic;


namespace OSGames.BoardGame {

    public class ActionMenuCommand : Command {

        protected ActionMenuController m_ActionMenuController;
        public ActionMenuController ActionMenuController {get {return m_ActionMenuController;}}

        RoomAction m_RoomAction;
        public RoomAction RoomAction{
            get {return m_RoomAction;}
        }

        public ActionMenuCommand(ActionMenuController actionMenu){
            SetActionMenuController(actionMenu);
        }

        public ActionMenuCommand(ActionMenuController actionMenu, RoomAction action){
            SetActionMenuController(actionMenu);
            m_RoomAction = action;
        }

        public void SetActionMenuController(ActionMenuController actionMenu){
            m_ActionMenuController = actionMenu;
        }

        override public void Execute(){
            Debug.Log("Executed Generic Action Menu Command!");
            m_ActionMenuController.RequestAction(m_RoomAction);
        }

        // public virtual void Undo(){

        // }
    }

}