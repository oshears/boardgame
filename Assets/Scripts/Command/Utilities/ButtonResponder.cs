using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BoardGame {

    [RequireComponent(typeof(Button))]
    public class ButtonResponder : MonoBehaviour
    {
        Button m_Button;

        Command m_Command;
        public Command Command{
            get { return m_Command; }
            set { m_Command = value; }
        }
        
        Scheduler m_Scheduler;
        public Scheduler Scheduler{
            get { return m_Scheduler; }
            set { m_Scheduler = value; }
        }

        void Awake(){
            m_Button = GetComponent<Button>();
            m_Button.onClick.AddListener(OnButtonPress);
        }

        void OnButtonPress(){
            m_Scheduler.AddCommand(m_Command);
        }

    }
}