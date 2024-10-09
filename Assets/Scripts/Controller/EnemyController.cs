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

    [RequireComponent(typeof(EnemyModel))]
    public class EnemyController : Controller, IScheduler
    {

        EnemyModel m_EnemyModel;

        Scheduler m_Scheduler;


        protected virtual void Awake(){
            m_EnemyModel = GetComponent<EnemyModel>();
            m_Scheduler = new Scheduler();
        }

        public void ExecuteCommand(ICommand cmd)
        {
            m_Scheduler.ExecuteCommand(cmd);
        }

        public ICommand UndoCommand()
        {
            return m_Scheduler.UndoCommand();
        }

    }
}