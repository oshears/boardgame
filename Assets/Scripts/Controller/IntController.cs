using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BoardGame {

    // [[RequireComponent(typeof(Subscriber))]]
    // [[RequireComponent(typeof(Publisher))]]
    public abstract class IntController : Controller<int>
    {

        override public void OnPublisherAction(int i){
            Debug.Log($"got int: {i}");
        }

    }
}