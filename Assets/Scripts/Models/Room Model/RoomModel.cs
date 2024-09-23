using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

using OSGames.BoardGame.Interactables;

namespace OSGames.BoardGame {

    public class RoomModel : Model {

        [SerializeField] RoomModel[] m_NeighboringRooms;

        [SerializeField] Transform m_PlayerStandLocation;

        [SerializeField] PlayerModel m_PlayersInRoom;

        InteractableModel m_TargetedInteractable;
        [SerializeField] List<InteractableModel> m_Interactables;
        public InteractableModel TargetedInteractable {
            get { return m_TargetedInteractable;}
            set { m_TargetedInteractable = value;}
        }

        [SerializeField] InteractableModel m_InitialInteractable;
        public InteractableModel InitialInteractable {
            get { return m_InitialInteractable;}
            set { m_InitialInteractable = value;}
        }

        RoomConfiguration m_RoomSO;

        protected void Awake(){
            for(int i = 0; i < m_Interactables.Count; i++){
                m_Interactables[i].NextInteractable = m_Interactables[(i + 1) % m_Interactables.Count];
                m_Interactables[i].PrevInteractable = m_Interactables[i > 0 ? i - 1 : m_Interactables.Count - 1];
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


        
    }

}