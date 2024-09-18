using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BoardGame {

    public class CommandListPublisher : Publisher<List<Command>> 
    {

        [SerializeField] List<Command> cmdList = new List<Command>();
        [SerializeField] bool testBool;


        public void TestPublish(){
            cmdList = new List<Command>();
            for(int i = 0; i < 5; i++){
                cmdList.Add(new ActionMenuCmd(null));
            }
            Publish(cmdList);    
        }
        private void OnGUI() {
            
            // if (GUILayout.Button("Publish Command List")){
                
            // }
        }
    }
}