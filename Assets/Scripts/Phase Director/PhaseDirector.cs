using UnityEngine;

namespace OSGames.BoardGame{

    /// <summary>
    /// Class that controls the flow of the game <c>Point</c>.
    /// </summary>
    [Icon("Packages/com.osgames.boardgame/Assets/Icons/osgames_logo.png")]
    public class PhaseDirector : MonoBehaviour {
        ///
        /// test
        ///
        
        [ContextMenuItem("Update Phase Count", "UpdatePhaseCount")]
        [Min(0)]
        [SerializeField] int m_NumPhases;
        [Min(0)]
        [SerializeField] int m_CurrentPhase;

    
        void UpdatePhaseCount(){
            Debug.Log("Updated phase count");
        }

    }
}