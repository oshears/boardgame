using UnityEngine;


namespace OSGames.BoardGame {

    public class RoomCommand : Command {

        protected RoomController m_RoomController;
        public RoomController RoomController {get {return m_RoomController;}}

        RoomAction m_RoomAction;
        public RoomAction RoomAction{
            get {return m_RoomAction;}
        }

        public RoomCommand(RoomController roomController){
            SetRoomController(roomController);
        }

        public RoomCommand(RoomController roomController, RoomAction action){
            SetRoomController(roomController);
            m_RoomAction = action;
        }

        public void SetRoomController(RoomController roomController){
            m_RoomController = roomController;
        }

        override public void Execute(){
            Debug.Log("Executed Generic Room Command!");
            // ActionMenu.RequestAction(m_RoomAction);
        }

        // public virtual void Undo(){

        // }
    }

}