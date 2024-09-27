using OSGames.BoardGame.Generic;

namespace OSGames.BoardGame.Interactables {
    public interface ICycleableInteractable : IInteractable {

        public ICycleableInteractable GetNext();

        public ICycleableInteractable GetPrev();

        public void SetNext(ICycleableInteractable next);
        
        public void SetPrev(ICycleableInteractable prev);


    }
}