

namespace BoardGame {


    public interface IPublisher<T> {

        public void Publish(T t);
        
    }

}