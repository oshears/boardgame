using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OSGames.BoardGame.Generic;

namespace OSGames.BoardGame {

    // [RequireComponent(typeof(CommandPublisher))]
    public class Scheduler : MonoBehaviour, IScheduler {

        Queue<Command> m_CommandQueue;

        // public UnityEvent<Command> e_CommandAdded;

        public CommandPublisher m_CommandPublisher;

        private static Stack<ICommand> undoStack = new Stack<ICommand>();

        private void Awake() {
            m_CommandQueue = new Queue<Command>();
            // m_CommandPublisher = GetComponent<CommandPublisher>();
        }

        void OnEnable() {
            // e_CommandAdded.AddListener(OnCommandAdded);
        }

        private void OnDisable() {
            // e_CommandAdded.RemoveListener(OnCommandAdded);    
        }

        void Start(){

        }

        private void Update() {
            if (m_CommandQueue.Count > 0){
                Command cmd = m_CommandQueue.Dequeue();
                ExecuteCommand(cmd);
            }   
        }

        public void ExecuteCommand(Command cmd){
            cmd.Execute();
            undoStack.Push(cmd);
            // m_CommandPublisher.Publish(cmd);
        }

        public void AddCommand(Command cmd){
            m_CommandQueue.Enqueue(cmd);
        }

        public void OnCommandAdded(Command cmd){
            AddCommand(cmd);
        }

        public static void UndoCommand()
        {
            if (undoStack.Count > 0)
            {
                ICommand activeCommand = undoStack.Pop();
                activeCommand.Undo();
            }
        }

    }

}
