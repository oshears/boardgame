using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

using OSGames.BoardGame.Generic;
using OSGames.BoardGame.Input;
using OSGames.BoardGame.Interactables;

namespace OSGames.BoardGame {

    public abstract class MobDirector<T> : MonoBehaviour {

        // [SerializeField] List<T> m_MobControllers;

        // public virtual void ExecuteMobActions(){
        //     foreach (T mobController in m_MobControllers){
        //         // execute command on generic scheduler?
        //     }
        // }

    }

}