using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Events;

namespace BoardGame {

    [RequireComponent(typeof(CommandListSubscriber))]
    [RequireComponent(typeof(ButtonFactory))]
    [RequireComponent(typeof(Scheduler))]
    public class ActionMenuController : Controller<List<Command>>
    {

        // [SerializeField] CommandFactory m_CommandFactory;
        ButtonFactory m_ButtonFactory;
        Scheduler m_Scheduler;
        // CommandListSubscriber m_Subscriber;

        // [SerializeField] Command View Controller

        override protected void Awake(){
            base.Awake();
            m_ButtonFactory = GetComponent<ButtonFactory>();
            m_Scheduler = GetComponent<Scheduler>();
        }

        override protected void OnDestroy(){
            base.OnDestroy();
        }

        override public void OnPublisherAction(List<Command> cmds){
            // Debug.Log($"got int: {i}");

            // create and initialize buttons
            foreach (Command cmd in cmds){
                // m_CommandFactory.Make(cmd); // generate action menu command

                // factory
                // 1. make button
                // 2. set the callbacks (on button click, add command to scheduler)
                // 3. add to grid view
                ButtonFactroyProduct product = new ButtonFactroyProduct(cmd, m_Scheduler);
                m_ButtonFactory.Make(product);

                // buttons will simply add the command associated with them to the scheduler
            }
            
        }

    }
}