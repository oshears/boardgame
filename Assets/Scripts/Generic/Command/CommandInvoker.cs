
using System.Collections.Generic;

namespace OSGames.BoardGame {
    public class CommandInvoker
    {
        private static Stack<ICommand> undoStack = new Stack<ICommand>();
        public static void ExecuteCommand(ICommand command)
        {
            command.Execute();
            undoStack.Push(command);
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