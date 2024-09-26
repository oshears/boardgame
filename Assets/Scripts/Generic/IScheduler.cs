namespace OSGames.BoardGame.Generic{
    public interface IScheduler { 
        void ExecuteCommand(ICommand cmd);
        ICommand UndoCommand();
        // void AddCommand(Command cmd);
        // void OnCommandAdded(Command cmd);
    }
}