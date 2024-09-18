
using UnityEngine;

namespace BoardGame {

    // [CreateAssetMenu(fileName = "Command Factory", menuName = "Board Game/Command Factory", order = 0)]
    // public class CommandFactory
    // {
        
    //     // public virtual CommandFactory GetCommand()
    //     // {

    //     // }
    // }

    public class CommandFactory : Factory<Command>
    {
        
        // public virtual CommandFactory GetCommand()
        // {

        // }

        override public void Make(Command cmd){
            // make command
            // add to visual view?
        }
    }
}