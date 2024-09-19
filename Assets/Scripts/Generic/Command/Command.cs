using UnityEngine;

namespace OSGames.BoardGame {
    public class Command : ICommand {

        // [Tooltip("Execution delay before running the command.")]
        public float Delay;


        public virtual void Execute() {
            Debug.Log($"Executed Command! {this}");
        }

        public virtual void Undo(){
            Debug.Log($"Undone Command! {this}");
        }
    }

}