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

    public class PlayerDeck<T> : ScriptableObject {

        [SerializeField] List<T> m_ActionPool;
        public List<T> actionPool { get {return m_ActionPool;} } 

        Stack<T> m_ActionStack;
        public Stack<T> actionStack { get {return m_ActionStack;} }

        List<T> m_AvailableActions;
        public List<T> availableActions { get {return m_AvailableActions;} }

        List<T> m_DiscardedActions;
        public List<T> discardedAction { get {return m_DiscardedActions;} }


        public void InitializeDeck(){
            m_ActionStack = new Stack<T>(m_ActionPool);
            m_AvailableActions = new List<T>();
            m_DiscardedActions = new List<T>();
        }

        public T DrawAction(){
            T action = m_ActionStack.Pop();
            m_AvailableActions.Add(action);
            return action;
        }

        public void DiscardAction(T action){
            m_AvailableActions.Remove(action);
            m_DiscardedActions.Add(action);
        }

        public void ShuffleInDiscardedActions(){
            ListFunctions.ShuffleList(m_DiscardedActions);
            foreach (T action in m_DiscardedActions){
                m_ActionStack.Push(action);
            }
        }
        
    }

}