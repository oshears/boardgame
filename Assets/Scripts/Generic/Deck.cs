using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OSGames.Utilities;

namespace OSGames.BoardGame.Generic {

    public abstract class Deck<T> : ScriptableObject
    {

        [SerializeField] List<T> m_ActionPool;
        public List<T> actionPool { get {return m_ActionPool;} } 

        Stack<T> m_ActionStack;
        public Stack<T> actionStack { get {return m_ActionStack;} }


        List<T> m_DiscardedActions;
        public List<T> discardedAction { get {return m_DiscardedActions;} }

        public bool isEmpty {
            get {
                return m_ActionStack.Count == 0;
            }
        }


        public virtual void InitializeDeck(){
            m_ActionStack = new Stack<T>(m_ActionPool);
            m_DiscardedActions = new List<T>();
        }

        public virtual T DrawAction(){
            T action = m_ActionStack.Pop();
            return action;
        }

        public virtual void DiscardAction(T action){
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