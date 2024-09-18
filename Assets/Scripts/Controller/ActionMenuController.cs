using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
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

        [SerializeField] CommandFactory m_CommandFactory;
        ButtonFactory m_ButtonFactory;
        Scheduler m_Scheduler;
        // CommandListSubscriber m_Subscriber;

        // [SerializeField] Command View Controller

        List<GameObject> m_Buttons;

        RoomActionPublisher m_RoomActionPublisher;

        // ToDo: do this later, it's just for polish
        // [Tooltip("Number of buttons that will appear in a row")]
        // [SerializeField] int ButtonSpacing = 4;

        override protected void Awake(){
            base.Awake();
            m_ButtonFactory = GetComponent<ButtonFactory>();
            m_Scheduler = GetComponent<Scheduler>();
            m_RoomActionPublisher = GetComponent<RoomActionPublisher>();
            m_Buttons = new List<GameObject>();
        }

        override protected void OnDestroy(){
            base.OnDestroy();
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