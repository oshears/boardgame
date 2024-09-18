using UnityEngine;


namespace BoardGame {

    public class ActionMenuCmd : Command {

        ActionMenuController m_ActionMenuController;
        public ActionMenuController ActionMenu {get {return m_ActionMenuController;}}

        public ActionMenuCmd(ActionMenuController actionMenu){
            SetActionMenuController(actionMenu);
        }

        public void SetActionMenuController(ActionMenuController actionMenu){
            m_ActionMenuController = actionMenu;
        }

        // public virtual void Execute(){
        //     Debug.Log("Executed Generic Action Menu Command!");
        // }

        // public virtual void Undo(){

        // }
    }

}