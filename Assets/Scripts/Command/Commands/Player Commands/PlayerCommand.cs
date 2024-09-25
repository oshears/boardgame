using UnityEngine;
using OSGames.BoardGame.Generic;


using OSGames.BoardGame;

namespace OSGames.BoardGame.Player {

    public class PlayerCommand : Command {

        protected PlayerController m_PlayerController;
        public PlayerController PlayerController {get {return m_PlayerController;}}


        public PlayerCommand(PlayerController playerController){
            SetPlayerController(playerController);
        }

        public void SetPlayerController(PlayerController playerController){
            m_PlayerController = playerController;
        }

        override public void Execute(){
            Debug.Log("Executed Generic Player Command!");
            // ActionMenu.RequestAction(m_RoomAction);
        }

        // public virtual void Undo(){

        // }
    }

}