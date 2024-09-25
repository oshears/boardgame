using OSGames.BoardGame.Generic;

namespace OSGames.BoardGame.Interactables {
    public interface ICycleableInteractable : IInteractable {

        IInteractable GetNext();

        IInteractable GetPrev();

    }
}