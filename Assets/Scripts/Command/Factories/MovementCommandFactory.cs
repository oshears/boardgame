
using UnityEngine;

namespace OSGames.BoardGame {
    
    // [CreateAssetMenu(fileName = "Command Factory", menuName = "Board Game/Command Factory", order = 0)]
    public class MovementCommandFactory : CommandFactory
    {
        public MovementCommandFactory command;
        // public MovementCommand GetCommand(){
        //     return CreateInstance<MovementCommand>();
        // }
    }
}