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

    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyModel : Controller
    {

        NavMeshAgent m_Agent;

        RoomModel m_CurrentRoom;

        public RoomModel currentRoom {
            get { return m_CurrentRoom; }
            set { m_CurrentRoom = value; }
        }

        void Awake(){
            m_Agent = GetComponent<NavMeshAgent>();
        }

    }
}