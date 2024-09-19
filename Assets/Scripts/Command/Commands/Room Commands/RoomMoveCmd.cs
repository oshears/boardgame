using UnityEngine;
using UnityEngine.AI;

namespace BoardGame {
    public class RoomMoveCommand : RoomCommand {

        NavMeshAgent m_Agent;
        Transform m_Destination;

        public RoomMoveCommand(RoomController roomController, NavMeshAgent agent, Transform destination) : base(roomController){
            m_Agent = agent;
            m_Destination = destination;
        }

        override public void Execute(){
            m_Agent.SetDestination(m_Destination.position);
        }

        

    }

}