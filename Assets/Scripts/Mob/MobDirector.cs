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

    
    [RequireComponent(typeof(PhaseEventSubscriber))]
    // [RequireComponent(typeof(MobDirectorEventPublisher<T>))]
    [Icon("Packages/com.osgames.boardgame/Assets/Icons/osgames_logo.png")]
    public abstract class MobDirector<T> : Controller {

        PhaseEventSubscriber m_PhaseEventSubscriber;
        MobDirectorEventPublisher<T> m_Publisher;
        public MobDirectorEventPublisher<T> publisher {
            get { return m_Publisher; }
        }

        protected virtual void Awake(){
            m_PhaseEventSubscriber = GetComponent<PhaseEventSubscriber>();

            m_Publisher = GetComponent<MobDirectorEventPublisher<T>>();

        }

        void Start(){
            m_PhaseEventSubscriber.PublisherAction += OnPhaseEvent;
        }

        protected virtual void OnPhaseEvent(PhaseEvent phaseEvent){
            
        }

    }

}