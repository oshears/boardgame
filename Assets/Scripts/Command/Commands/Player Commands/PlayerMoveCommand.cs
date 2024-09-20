using System;
using UnityEngine;
using UnityEngine.AI;

namespace OSGames.BoardGame {
    public class PlayerMoveCommand : PlayerCommand {

        Transform m_Destination;

        Publisher<RoomAction> m_Publisher;

        public PlayerMoveCommand(PlayerController playerController, Transform destination, Publisher<RoomAction> publisher) : base(playerController){
            m_Destination = destination;
            m_Publisher = publisher;
        }

        override public void Execute(){
            m_PlayerController.PlayerModel.Agent.SetDestination(m_Destination.position);
            m_PlayerController.PlayerModel.Animator.SetTrigger("Move");

            m_PlayerController.m_RoomActionSubscriber.PublisherToObserve = m_Publisher;
        }

        

    }

}