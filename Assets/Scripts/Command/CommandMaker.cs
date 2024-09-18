using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BoardGame {

    public class CommandMaker : MonoBehaviour {

        CommandFactory m_Factory;

        Scheduler m_Scheduler;


        public void Start(){
            m_Factory = new CommandFactory();
        }


        public void MakeCommand(){
            // m_Factory
        }

    }
}