using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BoardGame {

    public class RoomActionListPublisher : Publisher<List<RoomAction>> 
    {

        // [SerializeField] List<RoomAction> cmdList = new List<RoomAction>();
        // [SerializeField] bool testBool;


        public void TestPublish(){
            // cmdList = new List<RoomAction>();
            // for(int i = 0; i < 5; i++){
            //     cmdList.Add(new RoomAction(null));
            // }
            // Publish(cmdList);    
        }
        
    }
}