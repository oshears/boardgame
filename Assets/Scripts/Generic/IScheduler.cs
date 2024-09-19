namespace OSGames.BoardGame{
    public interface IScheduler { 
        void ExecuteCommand(Command cmd);
        void AddCommand(Command cmd);
        void OnCommandAdded(Command cmd);
    }
}