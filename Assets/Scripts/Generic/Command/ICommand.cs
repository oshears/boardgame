namespace OSGames.BoardGame.Generic {


    public interface ICommand {
        void Execute();

        void Undo();
    }

}