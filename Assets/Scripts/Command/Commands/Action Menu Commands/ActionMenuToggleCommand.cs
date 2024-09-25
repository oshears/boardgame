using UnityEngine;
using DG.Tweening;

namespace OSGames.BoardGame {

    public class ActionMenuToggleCommand : ActionMenuCommand {
        
        bool m_Active;
        
        public ActionMenuToggleCommand(ActionMenuController actionMenu) : base(actionMenu)
        {
            // m_Active = active;
        }

        override public void Execute(){
            Debug.Log("Executed Action Menu Toggle Command!");
            if (m_ActionMenuController.ActionMenu.CanvasGroup.interactable){
                // m_ActionMenuController.ActionMenu.CanvasGroup.alpha = 0;
                m_ActionMenuController.ActionMenu.CanvasGroup.DOFade(0f, 0.25f);
                m_ActionMenuController.ActionMenu.CanvasGroup.interactable = false;
            }
            else{
                // m_ActionMenuController.ActionMenu.CanvasGroup.alpha = 1;
                m_ActionMenuController.ActionMenu.CanvasGroup.DOFade(1f, 0.25f);
                m_ActionMenuController.ActionMenu.CanvasGroup.interactable = true;
                // m_ActionMenuController.ActionMenu.CanvasGroup.DOFlip
            }
            
        }

    }

}