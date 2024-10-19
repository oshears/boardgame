using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;
using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Player;
using OSGames.BoardGame.Interactables;
using UnityEditor.EditorTools;

namespace OSGames.BoardGame {

    [RequireComponent(typeof(RoomModel))]
    public class RoomController : Controller
    {
        RoomConfiguration m_RoomSO;

        RoomModel m_RoomModel;
        public virtual RoomModel RoomModel { get { return m_RoomModel;}}


        [SerializeField] RoomController[] m_NeighboringRooms;

        [SerializeField] Transform m_PlayerStandLocation;

        [SerializeField] Vector3 m_RoomBounds = new Vector3(15,10,10);
        public Vector3 roomBounds { get { return m_RoomBounds;}}

        List<PlayerController> m_PlayersInRoom;
        public List<PlayerController> playersInRoom {
            get {return m_PlayersInRoom;}
            set {m_PlayersInRoom = value;}
        }

        [Tooltip("Interactables within range of this room.")]
        [SerializeField] List<InteractableController> m_Interactables;
        public List<InteractableController> interactables {
            get {return m_Interactables;}
            set {m_Interactables = value;}
        }


        protected virtual void Awake(){
            
            m_RoomModel = GetComponent<RoomModel>();

            if (m_PlayersInRoom == null){
                m_PlayersInRoom = new List<PlayerController>();
            } 
        }

        void OnDestroy(){

        }



        public void Publish(){

        }

        public Vector3 GetPlayerStandLocation(){
            return m_PlayerStandLocation == null ? transform.position : m_PlayerStandLocation.position;
        }

        public Transform GetPlayerStandTransform(){
            return m_PlayerStandLocation == null ? transform : m_PlayerStandLocation;
        }

        public RoomController GetNeighboringRoom(int index){
            return m_NeighboringRooms[index];
        }

        public Transform GetNeighboringPlayerStandTransform(int index){
            return m_NeighboringRooms[index].GetPlayerStandTransform();
        }

        public void RegisterPlayer(PlayerController player){
            // m_Interactables.Add(player);
            m_PlayersInRoom.Add(player);
        }

        public void RemovePlayer(PlayerController player){
            m_PlayersInRoom.Remove(player);
        }

        #if UNITY_EDITOR

        override protected void OnDrawGizmosSelected() {
            
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position,m_RoomBounds);

        }
        #endif

    }
}