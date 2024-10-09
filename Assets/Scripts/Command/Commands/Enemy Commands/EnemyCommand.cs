using UnityEngine;
using OSGames.BoardGame.Generic;


using OSGames.BoardGame;

namespace OSGames.BoardGame {

    public class EnemyCommand : Command {

        protected EnemyController m_EnemyController;
        public EnemyController enemyController {get {return m_EnemyController;}}


        public EnemyCommand(EnemyController enemyController){
            SetEnemyController(enemyController);
        }

        public void SetEnemyController(EnemyController enemyController){
            m_EnemyController = enemyController;
        }

        override public void Execute(){
            Debug.Log("Executed Generic Enemy Command!");
            // ActionMenu.RequestAction(m_RoomAction);
        }

        // public virtual void Undo(){

        // }
    }

}