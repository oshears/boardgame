using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BoardGame {

    [RequireComponent(typeof(RoomActionListSubscriber))]
    // [RequireComponent(typeof(CommandFactory))]
    [RequireComponent(typeof(ButtonFactory))]
    [RequireComponent(typeof(Scheduler))]
    [RequireComponent(typeof(RoomActionPublisher))]
    public class ActionMenuController : Controller<List<RoomAction>>
    {

        // [SerializeField] CommandFactory m_CommandFactory;

        Scheduler m_Scheduler;
        // CommandListSubscriber m_Subscriber;
        // [SerializeField] Command View Controller
        RoomActionPublisher m_RoomActionPublisher;

        ButtonFactory m_ButtonFactory;
        List<GameObject> m_Buttons;


        override protected void Awake(){
            base.Awake();
            m_Scheduler = GetComponent<Scheduler>();
            m_RoomActionPublisher = GetComponent<RoomActionPublisher>();
            m_ButtonFactory = GetComponent<ButtonFactory>();
            m_Buttons = new List<GameObject>();
        }

        override public void OnPublisherAction(List<RoomAction> roomActions){
            // Debug.Log($"got int: {i}");

            // create and initialize buttons
            foreach (RoomAction roomAction in roomActions){
                // m_CommandFactory.Make(cmd); // generate action menu command

                // factory
                // 1. make button
                // 2. set the callbacks (on button click, add command to scheduler)
                // 3. add to grid view
                // ActionMenuCmd cmd = new ActionMenuCmd(this, roomAction.ActionType);
                ButtonFactroyProduct product = new ButtonFactroyProduct(this, roomAction, m_Scheduler);
                GameObject btn = m_ButtonFactory.Make(product);
                m_Buttons.Add(btn);

                // buttons will simply add the command associated with them to the scheduler
            }

        }

        

        public void RequestAction(RoomAction roomAction){
            // send information to observers that this is the command requested by the player
            // decide what to do next based on the selected action
            // ^^ this could probably be done in the actual commands, not here
            Debug.Log($"User requested to perform the following action: {roomAction}");
            m_RoomActionPublisher.Publish(roomAction);
        }

    }
}