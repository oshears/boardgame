using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;
// using Cinemachine;

using OSGames.BoardGame.Generic;
using TMPro;

namespace OSGames.BoardGame.Player {

    
    public class PlayerMenuModel : Model {
        [SerializeField] protected CanvasGroup m_CanvasGroup;
        public CanvasGroup CanvasGroup {get {return m_CanvasGroup;} }

        [SerializeField] bool m_MenuActive;

        public bool MenuActive {
            get {return m_MenuActive;}
            set {SetMenu(value);}
        }

        [SerializeField] TextMeshProUGUI m_PlayerHint;
        public string hintText {
            get {return m_PlayerHint.text;}
            set {m_PlayerHint.text = value;}
        }

        override protected void Awake(){
            base.Awake();
        }

        override protected void Start(){
            base.Start();
            SetMenu(false);
        }

        public virtual bool ToggleMenu(){
            SetMenu(!m_MenuActive);
            return m_MenuActive;
        }

        public virtual void SetMenu(bool active){
            m_MenuActive = active;
            m_CanvasGroup.alpha = active ? 1 : 0;
            m_CanvasGroup.interactable = active;
            m_CanvasGroup.blocksRaycasts = active;
        }

        public virtual bool GetAtBaseMenu(){
            return true;
        }

    }
}