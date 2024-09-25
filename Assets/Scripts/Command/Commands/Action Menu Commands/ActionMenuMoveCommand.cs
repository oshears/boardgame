using UnityEngine;
using OSGames.BoardGame.Generic;

namespace OSGames.BoardGame {

    public class ActionMenuMoveCommand : ActionMenuCommand {
        public ActionMenuMoveCommand(ActionMenuController actionMenu, RoomAction roomAction) : base(actionMenu,roomAction)
        {
            
        }

        override public void Execute(){
            Debug.Log("Executed Action Menu Move Command!");

            // m_ActionMenuController.RoomActionListSubscriber.PublisherToObserve = ((MovementAction) m_RoomAction).DestinationRoomActionListPublisher;
            // m_ActionMenuController.RoomActionSubscriber.PublisherToObserve = ((MovementAction) m_RoomAction).DestinationRoomPublisher;
            // m_ActionMenuController.RequestAction(RoomAction);
        }

    }

}