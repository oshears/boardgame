using UnityEngine;


namespace BoardGame {

    public class PlayerCommand : Command {

        PlayerController m_PlayerController;
        public PlayerController PlayerController {get {return m_PlayerController;}}

        RoomAction m_RoomAction;
        public RoomAction RoomAction{
            get {return m_RoomAction;}
        }

        public PlayerCommand(PlayerController playerController){
            SetPlayerController(playerController);
        }

        public PlayerCommand(PlayerController playerController, RoomAction action){
            SetPlayerController(playerController);
            m_RoomAction = action;
        }

        public void SetPlayerController(PlayerController playerController){
            m_PlayerController = playerController;
        }

        override public void Execute(){
            Debug.Log("Executed Generic Room Command!");
            // ActionMenu.RequestAction(m_RoomAction);
        }

        // public virtual void Undo(){

        // }
    }

}