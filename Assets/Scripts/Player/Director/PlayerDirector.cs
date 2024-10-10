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
using OSGames.BoardGame.Player;

namespace OSGames.BoardGame {

    /// <summary>
    /// Generic player director class. This class will be subclassed by the following:
    /// @TODO: Turn based player director
    /// @TODO: networked / realtime player director (stretch goal)
    /// This director is in charge of the following:
    /// 
    /// <list type="bullet"> <item>if a player passes their turn, handle the process of changing to the next player</item>
    /// <item>if a player performs an action, check if we should switch to the next player</item></list>
    /// </summary>
    [RequireComponent(typeof(PhaseEventSubscriber))]
    [RequireComponent(typeof(PlayerDirectorEventPublisher))]
    [RequireComponent(typeof(PlayerEventSubscriber))]
    public class PlayerDirector : Controller {
        PhaseEventSubscriber m_PhaseEventSubscriber;
        PlayerEventSubscriber m_PlayerEventSubscriber;
        PlayerDirectorEventPublisher m_Publisher;
        public PublisherBehaviour<PlayerDirectorEvent> publisher {
            get { return m_Publisher; }
        }


        public int currentPlayerTurn;

        [SerializeField] List<PlayerController> m_Players;
        public List<PlayerController> players {
            get { return m_Players; }
        }

        protected virtual void Awake(){
            m_PhaseEventSubscriber = GetComponent<PhaseEventSubscriber>();
            m_PlayerEventSubscriber = GetComponent<PlayerEventSubscriber>();

            m_Publisher = GetComponent<PlayerDirectorEventPublisher>();

            if (m_Players == null){
                m_Players = new List<PlayerController>();
            }

        }

        void Start(){
            m_PhaseEventSubscriber.PublisherAction += OnPhaseEvent;
            m_PlayerEventSubscriber.PublisherAction += OnPlayerEvent;
        }

        protected virtual void OnPhaseEvent(PhaseEvent phaseEvent){
            Command cmd = new PlayerDirectorProcessPhaseEventCommand(this,phaseEvent);
            cmd.Execute();
        }

        protected virtual void OnPlayerEvent(PlayerEvent playerEvent){
            Command cmd = new PlayerDirectorProcessPlayerEventCommand(this,playerEvent);
            cmd.Execute(); 
        }

    }

}