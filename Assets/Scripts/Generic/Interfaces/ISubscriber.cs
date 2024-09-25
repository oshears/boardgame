namespace OSGames.BoardGame.Generic {
    public interface ISubscriber<T> {
        public void SubscribeTo(IPublisher<T> publisher);

        public void UnsubscribeFrom(IPublisher<T> publisher);
    }

}