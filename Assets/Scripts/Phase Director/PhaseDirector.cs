using OSGames.BoardGame.Generic;
using UnityEngine;

namespace OSGames.BoardGame{

    public enum PhaseState{
        None,
        PlayerPhase,
        EventPhase,
    }

    /// <summary>
    /// Class that controls the flow of the game.
    /// </summary>
    [Icon("Packages/com.osgames.boardgame/Assets/Icons/osgames_logo.png")]
    [RequireComponent(typeof(PhaseEventPublisher))]
    [RequireComponent(typeof(PhaseDirectorModel))]
    [RequireComponent(typeof(PlayerEventSubscriber))]
    [RequireComponent(typeof(MobDirectorEventSubscriber<Controller>))]
    public class PhaseDirector : Controller {
        ///
        /// test
        ///
        
        [ContextMenuItem("Update Phase Count", "UpdatePhaseCount")]
        [Min(0)]
        [SerializeField] int m_NumPhases;
        [Min(0)]
        [SerializeField] int m_CurrentPhase;

        SubscriberBehaviour<PlayerEvent> m_PlayerEventSubscriber;
        SubscriberBehaviour<MobDirectorEvent<Controller>> m_MobDirectorEventSubscriber;

        PublisherBehaviour<PhaseEvent> m_Publisher;
        public PublisherBehaviour<PhaseEvent> publisher {
            get {return m_Publisher; }
        }

        [SerializeField] PhaseState m_State;
        public PhaseState state {
            get { return m_State; }
        }

        PhaseDirectorModel m_PhaseDirectorModel;

        protected virtual void Awake(){
            m_Publisher = GetComponent<PublisherBehaviour<PhaseEvent>>();
            m_PhaseDirectorModel = GetComponent<PhaseDirectorModel>();

            m_PlayerEventSubscriber.PublisherAction += OnPlayerEvent;
            m_MobDirectorEventSubscriber.PublisherAction += OnMobDirectorEvent;
        }

    
        void UpdatePhaseCount(){
            Debug.Log("Updated phase count");
        }

        public void ExecuteNextPhase(){

        }

        protected virtual void OnMobDirectorEvent(MobDirectorEvent<Controller> mobDirectorEvent){
            Debug.Log("Received message from mob director");
        }

        protected virtual void OnPlayerEvent(PlayerEvent playerEvent){
            Debug.Log("Received message from player controller");
        }

    }
}