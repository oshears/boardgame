using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

namespace OSGames.BoardGame {

    public class RoomModel : Model {

        [SerializeField] RoomModel[] m_NeighboringRooms;

        [SerializeField] Transform m_PlayerStandLocation;

        [SerializeField] PlayerModel m_PlayersInRoom;

        [SerializeField] InteractableModel m_TargetedInteractable;
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