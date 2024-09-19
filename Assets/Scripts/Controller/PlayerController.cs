using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BoardGame {

    // [RequireComponent(typeof(RoomActionListSubscriber))]
    // [RequireComponent(typeof(CommandFactory))]
    // [RequireComponent(typeof(ButtonFactory))]
    // [RequireComponent(typeof(Scheduler))]
    [RequireComponent(typeof(RoomActionSubscriber))] // recieve commands from the player
    [RequireComponent(typeof(RoomActionListPublisher))] // send available commands to the player HUD
    [RequireComponent(typeof(RoomActionPublisher))] // send commands to the player and the room
    [RequireComponent(typeof(Scheduler))]
    [RequireComponent(typeof(RoomCommandFactory))]
    public class PlayerController : Controller<RoomAction>
    {

    }
}