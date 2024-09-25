using UnityEngine;
using OSGames.BoardGame.Generic;


namespace OSGames.BoardGame.Input {

    public class InputCommand : Command {

        protected PlayerInputController m_PlayerInputController;

        RoomAction m_RoomAction;

        protected InputType m_InputType;

        public RoomAction RoomAction{
            get {return m_RoomAction;}
        }

        public InputCommand(PlayerInputController playerInputController){
            m_PlayerInputController = playerInputController;
        }

        public InputCommand(PlayerInputController playerInputController, InputType inputType){
            m_PlayerInputController = playerInputController;
            m_InputType = inputType;
        }

        public InputCommand(PlayerInputController playerInputController, RoomAction action){
            m_PlayerInputController = playerInputController;
            m_RoomAction = action;
        }

        override public void Execute(){
            Debug.Log("Executed Generic Input Command!");
            // ActionMenu.RequestAction(m_RoomAction);
            m_PlayerInputController.Publish(m_InputType);
        }

        // public virtual void Undo(){

        // }
    }

}