namespace BoardGame {


    public interface ICommand {
        void Execute();

        void Undo();
    }

}