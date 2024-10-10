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

        protected virtual void NotifySubscribers(){
            m_PlayerController.publisher.Publish(new PlayerEvent(m_PlayerController,PlayerEventType.ExecuteAction));
        }

        protected override void DoneExecution()
        {
            base.DoneExecution();
            NotifySubscribers();
        }

        // public virtual void Undo(){

        // }
    }

}