using System;
using UnityEngine;

namespace OSGames.BoardGame.Generic {
    public class Command : ICommand {

        // [Tooltip("Execution delay before running the command.")]
        public float Delay;

        public event Action e_ExecutionDone;

        public virtual void Execute() {
            Debug.Log($"Executed Command! {this}");
        }

        public virtual void Undo(){
            Debug.Log($"Undone Command! {this}");
        }

        public virtual void DoneExecution(){
            if (e_ExecutionDone != null){
                e_ExecutionDone();
            }
            else{
                Debug.LogError("done execution invoked with no active listeners.");
            }
        }
    }

}