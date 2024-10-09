using UnityEngine;

namespace OSGames.BoardGame{

    /// <summary>
    /// Class that controls the flow of the game <c>Point</c>.
    /// </summary>
    [IconAttribute("../Assets/Icons/osgames_logo")]
    public class PhaseDirector : MonoBehaviour {
        ///
        /// test
        ///
        
        [ContextMenuItem("Update Phase Count", "UpdatePhaseCount")]
        [Min(0)]
        [SerializeField] int m_NumPhases;
        [SerializeField] int m_CurrentPhase;

    
        void UpdatePhaseCount(){

        }

    }
}