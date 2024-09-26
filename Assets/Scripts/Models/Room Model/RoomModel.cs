using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

using OSGames.BoardGame.Interactables;
using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Player;

namespace OSGames.BoardGame {

    public class RoomModel : Model {

        [SerializeField] RoomModel[] m_NeighboringRooms;

        [SerializeField] Transform m_PlayerStandLocation;

        [SerializeField] List<PlayerModel> m_PlayersInRoom;

        ICycleableInteractable m_TargetedInteractable;
        [SerializeField] List<InteractableModel> m_Interactables;
        public ICycleableInteractable TargetedInteractable {
            get { return m_TargetedInteractable;}
            set { m_TargetedInteractable = value;}
        }

        [SerializeField] InteractableModel m_InitialInteractable;
        public ICycleableInteractable InitialInteractable {
            get { return m_InitialInteractable;}
            // set { m_InitialInteractable = value;}
        }

        RoomConfiguration m_RoomSO;

        protected void Awake(){
            for(int i = 0; i < m_Interactables.Count; i++){
                m_Interactables[i].SetNext(m_Interactables[(i + 1) % m_Interactables.Count]);
                m_Interactables[i].SetPrev(m_Interactables[i > 0 ? i - 1 : m_Interactables.Count - 1]);
            }
        }

        public Vector3 GetPlayerStandLocation(){
            return m_PlayerStandLocation.position;
        }

        public Transform GetPlayerStandTransform(){
            return m_PlayerStandLocation;
        }

        public RoomModel GetNeighboringRoom(int index){
            return m_NeighboringRooms[index];
        }

        public Transform GetNeighboringPlayerStandTransform(int index){
            return m_NeighboringRooms[index].GetPlayerStandTransform();
        }

        public void RegisterPlayer(PlayerModel player){
            // m_Interactables.Add(player);
            m_PlayersInRoom.Add(player);
        }

        public void RemovePlayer(PlayerModel player){
            m_PlayersInRoom.Remove(player);
        }
    }

}