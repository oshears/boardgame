
using UnityEngine;
using OSGames.BoardGame.Generic;

namespace OSGames.BoardGame {

    // [CreateAssetMenu(fileName = "Command Factory", menuName = "Board Game/Command Factory", order = 0)]
    // public class CommandFactory
    // {
        
    //     // public virtual CommandFactory GetCommand()
    //     // {

    //     // }
    // }

    

    public class CommandFactory : Factory<RoomAction, Command>
    {
        
        // public virtual CommandFactory GetCommand()
        // {

        // }

        override public Command Make(RoomAction action){
            // make command
            // add to visual view?
            return new Command();
        }
    }
}