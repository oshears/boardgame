using UnityEngine;
using OSGames.BoardGame.Generic;


namespace OSGames.BoardGame {

    public class ActionMenuCmd : Command {

        ActionMenuController m_ActionMenuController;
        public ActionMenuController ActionMenu {get {return m_ActionMenuController;}}

        RoomAction m_RoomAction;
        public RoomAction RoomAction{
            get {return m_RoomAction;}
        }

        public ActionMenuCmd(ActionMenuController actionMenu){
            SetActionMenuController(actionMenu);
        }

        public ActionMenuCmd(ActionMenuController actionMenu, RoomAction action){
            SetActionMenuController(actionMenu);
            m_RoomAction = action;
        }

        public void SetActionMenuController(ActionMenuController actionMenu){
            m_ActionMenuController = actionMenu;
        }

        override public void Execute(){
            Debug.Log("Executed Generic Action Menu Command!");
            ActionMenu.RequestAction(m_RoomAction);
        }

        // public virtual void Undo(){

        // }
    }

}