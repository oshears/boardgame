using System;

namespace OSGames.BoardGame.Generic {

    public interface IPublisher<T>{

        public void Publish(T message);

        public void AddListener(Action<T> func);
        public void RemoveListener(Action<T> func);

    }
}