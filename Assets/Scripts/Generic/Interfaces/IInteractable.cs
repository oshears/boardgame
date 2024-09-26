using UnityEngine;

namespace OSGames.BoardGame.Generic {

    public interface IInteractable{

        public void Use();

        public void FinishUse();

        public void SetHighlight();

        public void ClearHighlight();

        public Transform GetLookPosition();
        public Transform GetStandPosition();

        public Transform GetTransform();

    }
}