using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Input;
using OSGames.BoardGame.Interactables;

namespace OSGames.BoardGame {

    
    [RequireComponent(typeof(SubscriberBehaviour<PhaseEvent>))]
    // [RequireComponent(typeof(PublisherBehaviour<MobDirectorEvent<T>>))]
    [Icon("Packages/com.osgames.boardgame/Assets/Icons/osgames_logo.png")]
    public abstract class MobDirector<T> : Controller {

        SubscriberBehaviour<PhaseEvent> m_PhaseEventSubscriber;

        PublisherBehaviour<MobDirectorEvent<T>> m_Publisher;
        public PublisherBehaviour<MobDirectorEvent<T>> publisher {
            get { return m_Publisher; }
        }

        protected virtual void Awake(){
            m_PhaseEventSubscriber = GetComponent<SubscriberBehaviour<PhaseEvent>>();
            m_PhaseEventSubscriber.PublisherAction += OnPhaseEvent;

            m_Publisher = GetComponent<PublisherBehaviour<MobDirectorEvent<T>>>();

        }

        protected virtual void OnPhaseEvent(PhaseEvent phaseEvent){
            
        }

    }

}