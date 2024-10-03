using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Input;

namespace OSGames.BoardGame.Interactables {

    public enum InteractableEventType{
        InteractStart,
        InteractFinish,
    }

    public class InteractableEvent {
        InteractableEventType m_EventType;
        public InteractableEventType type {
            get {return m_EventType;}
            set {m_EventType = value;}
        }

        GameObject m_Sender;
        public GameObject sender {
            get {return m_Sender;}
            set {m_Sender = value;}
        }

        public InteractableEvent(GameObject sender, InteractableEventType type){
            m_Sender = sender;
            m_EventType = type;
        }
        
    }

}