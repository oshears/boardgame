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
    // [RequireComponent(typeof(MobDirectorEventSubscriber<Controller>))]
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
        // SubscriberBehaviour<MobDirectorEvent<Controller>> m_MobDirectorEventSubscriber;
        // public SubscriberBehaviour<MobDirectorEvent<Controller>> mobDirectorSubscriber {
        //     get { return m_MobDirectorEventSubscriber; }
        //     set {m_MobDirectorEventSubscriber = value;}
        // } 

        PublisherBehaviour<PhaseEvent> m_Publisher;
        public PublisherBehaviour<PhaseEvent> publisher {
            get {return m_Publisher; }
        }

        [SerializeField] PhaseState m_State;
        public PhaseState state {
            get { return m_State; }
            set { m_State = value; }
        }

        PhaseDirectorModel m_PhaseDirectorModel;

        protected virtual void Awake(){
            m_Publisher = GetComponent<PublisherBehaviour<PhaseEvent>>();
            m_PhaseDirectorModel = GetComponent<PhaseDirectorModel>();
            m_PlayerEventSubscriber = GetComponent<PlayerEventSubscriber>();
        }

        protected virtual void Start(){
            m_PlayerEventSubscriber.PublisherAction += OnPlayerEvent;
            // m_MobDirectorEventSubscriber.PublisherAction += OnMobDirectorEvent;
        }   

    
        void UpdatePhaseCount(){
            Debug.Log("Updated phase count");
        }

        public void ExecuteNextPhase(){
            Command cmd = new StartPhaseCommand(this);
            cmd.Execute();
        }

        

        protected virtual void OnPlayerEvent(PlayerEvent playerEvent){
            Debug.Log("Received message from player controller");
        }

    }
}