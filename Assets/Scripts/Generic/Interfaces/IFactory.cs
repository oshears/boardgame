namespace OSGames.BoardGame.Generic {

    public interface IFactory<T,U> {

        public U Make(T t);
    }


}