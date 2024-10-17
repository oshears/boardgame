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

        ICycleableInteractable m_TargetedInteractable;

        [Tooltip("Interactables within range of this room.")]
        [SerializeField] List<InteractableModel> m_Interactables;
        public List<InteractableModel> interactables {
            get {return m_Interactables;}
            set {m_Interactables = value;}
        }
        public ICycleableInteractable TargetedInteractable {
            get { return m_TargetedInteractable;}
            set { m_TargetedInteractable = value;}
        }

        [SerializeField] InteractableModel m_InitialInteractable;
        public ICycleableInteractable InitialInteractable {
            get { return m_InitialInteractable;}
            // set { m_InitialInteractable = value;}
        }



        protected virtual void Awake(){
            
            m_RoomModel = GetComponent<RoomModel>();

            // for(int i = 0; i < m_Interactables.Count; i++){
            //     m_Interactables[i].SetNext(m_Interactables[(i + 1) % m_Interactables.Count]);
            //     m_Interactables[i].SetPrev(m_Interactables[i > 0 ? i - 1 : m_Interactables.Count - 1]);
            // }
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

        private void OnDrawGizmosSelected() {
            
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position,m_RoomBounds);

        }
        #endif

    }
}