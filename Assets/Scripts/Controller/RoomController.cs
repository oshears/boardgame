using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;
using OSGames.BoardGame.Generic;

namespace OSGames.BoardGame {

    [RequireComponent(typeof(RoomModel))]
    public class RoomController : Controller
    {


        RoomModel m_RoomModel;
        public RoomModel RoomModel { get { return m_RoomModel;}}





        protected virtual void Awake(){
            m_RoomModel = GetComponent<RoomModel>();
        }

        void OnDestroy(){

        }



        public void Publish(){

        }

    }
}