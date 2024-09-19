using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;
// using Cinemachine;

namespace OSGames.BoardGame {

    
    public class ActionMenuModel : Model {
        [SerializeField] CanvasGroup m_CanvasGroup;
        public CanvasGroup CanvasGroup {get {return m_CanvasGroup;} }

        [SerializeField] bool m_MenuActive;

        public bool MenuActive{
            get {return m_MenuActive;}
            set {m_MenuActive = value;}
        }

    }
}