using UnityEngine;

namespace BoardGame {
    [CreateAssetMenu(fileName = "Command", menuName = "Board Game/Generic Command", order = 0)]
    public class Command : ScriptableObject, ICommand {

        [Tooltip("Execution delay before running the command.")]
        public float Delay;


        public virtual void Execute() {

        }
    }

}