using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Input;
using OSGames.BoardGame;
using OSGames.Utilities;
using OSGames.BoardGame.Actions;

namespace OSGames.BoardGame.Player {

    public class PlayerDeck<T> : Deck<T> {

        List<T> m_AvailableActions;
        public List<T> availableActions { get {return m_AvailableActions;} }

        public override void InitializeDeck()
        {
            base.InitializeDeck();
            m_AvailableActions = new List<T>();
        }

        override public T DrawAction(){
            T action = base.DrawAction();
            m_AvailableActions.Add(action);
            return action;
        }

        override public void DiscardAction(T action){
            base.DiscardAction(action);
            m_AvailableActions.Remove(action);
        }

    }

}