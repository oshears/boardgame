
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BoardGame {

    // [CreateAssetMenu(fileName = "Command Factory", menuName = "Board Game/Command Factory", order = 0)]
    // public class CommandFactory
    // {
        
    //     // public virtual CommandFactory GetCommand()
    //     // {

    //     // }
    // }

    public class RoomCommandFactory : Factory<RoomCommandProduct, RoomCommand>
    {
        public override RoomCommand Make(RoomCommandProduct product){


            return new RoomCommand(product.RoomController, product.RoomAction);
        }

    }

    public class RoomCommandProduct {
        public RoomController RoomController;
        public RoomAction RoomAction;
        public RoomCommandProduct(RoomController roomController, RoomAction roomAction)
        {
            RoomController = roomController;
            RoomAction = roomAction;
        }
    }
}