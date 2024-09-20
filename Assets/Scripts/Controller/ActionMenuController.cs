using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using OSGames.BoardGame.Generic;

namespace OSGames.BoardGame {

    [RequireComponent(typeof(RoomActionListSubscriber))]
    // [RequireComponent(typeof(CommandFactory))]
    [RequireComponent(typeof(ButtonFactory))]
    [RequireComponent(typeof(ActionMenuCommandFactory))]
    [RequireComponent(typeof(Scheduler))]
    [RequireComponent(typeof(RoomActionPublisher))]
    [RequireComponent(typeof(RoomActionSubscriber))]
    [RequireComponent(typeof(ActionMenuModel))]
    public class ActionMenuController : Controller
    {

        // [SerializeField] CommandFactory m_CommandFactory;

        Scheduler m_Scheduler;
        // CommandListSubscriber m_Subscriber;
        // [SerializeField] Command View Controller
        RoomActionListSubscriber m_RoomActionListSubscriber;
        public RoomActionListSubscriber RoomActionListSubscriber { get { return m_RoomActionListSubscriber;}}
        RoomActionSubscriber m_RoomActionSubscriber;
        public RoomActionSubscriber RoomActionSubscriber { get { return m_RoomActionSubscriber;}}
        RoomActionPublisher m_RoomActionPublisher;

        ButtonFactory m_ButtonFactory;
        ActionMenuCommandFactory m_CommandFactory;
        List<GameObject> m_Buttons;

        ActionMenuModel m_ActionMenu;
        public ActionMenuModel ActionMenu {get { return m_ActionMenu;}}

        void Awake(){
            m_Scheduler = GetComponent<Scheduler>();
            m_RoomActionPublisher = GetComponent<RoomActionPublisher>();
            m_ButtonFactory = GetComponent<ButtonFactory>();
            m_Buttons = new List<GameObject>();
            m_ActionMenu = GetComponent<ActionMenuModel>();
            m_CommandFactory = GetComponent<ActionMenuCommandFactory>();

            m_RoomActionListSubscriber = GetComponent<RoomActionListSubscriber>();
            m_RoomActionListSubscriber.PublisherAction += OnRoomActionListProvided;

            m_RoomActionSubscriber = GetComponent<RoomActionSubscriber>();
            m_RoomActionSubscriber.PublisherAction += OnRoomAction;
        }

        void OnDestroy()
        {
            m_RoomActionListSubscriber.PublisherAction -= OnRoomActionListProvided;
        }

        public void OnRoomActionListProvided(List<RoomAction> roomActions){
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

        void OnRoomAction(RoomAction roomAction){
            Debug.Log($"Action menu is responding to the user's chosen action: {roomAction}");

            ActionMenuCommandProduct product = new ActionMenuCommandProduct(this, roomAction);
            Command cmd = m_CommandFactory.Make(product);
            m_Scheduler.AddCommand(cmd);
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