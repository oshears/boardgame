using UnityEngine;
// using OSGames.BoardGame.Player;
using OSGames.BoardGame.Actions;
using System.Collections;
using UnityEngine.UI;

namespace OSGames.BoardGame.Actions {

    public class ActionHolder : MonoBehaviour, IActionHolder {

        protected PlayerAction m_Action;
        // public PlayerAction action {
        //     get {return m_Action;}
        //     set {m_Action = value;}
        // }  

        public virtual PlayerAction GetPlayerAction(){
            return m_Action;
        }

        public virtual void SetPlayerAction(PlayerAction action){
            m_Action = action;
        }
        
    }

}