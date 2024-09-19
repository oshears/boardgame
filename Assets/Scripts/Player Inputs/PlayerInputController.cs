using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static GameControlMap;
using OSGames.BoardGame;
using OSGames.BoardGame.Generic;
using System.Collections.Generic;
using OSGames.BoardGame.Input;
using OSGames.Utilities;
// using AY

namespace OSGames.BoardGame.Input {

    [RequireComponent(typeof(Scheduler))]
    [RequireComponent(typeof(RoomActionPublisher))]
    public class PlayerInputController : Controller, IActivePlayerControlsActions
    {

        private GameControlMap controls;   

        // TODO: define the action to scriptable object RoomAction mapping
        [SerializeField] List<RoomAction> m_RoomActions;
        [SerializeField] List<InputType> m_InputTypes;
        // Alternatviely I can just make an action for each and serailize them, but that's not as easily scalable and looks horrendeous

        Scheduler m_Scheduler;
        RoomActionPublisher m_RoomActionPublisher;
        public RoomActionPublisher RoomActionPublisher { get { return m_RoomActionPublisher;}}

        Dictionary<InputType,RoomAction> m_InputActionDict;
        // [SerializeField] SerializableDictionary<InputType,RoomAction> m_InputActionDict;


        void Awake(){
            m_RoomActionPublisher = GetComponent<RoomActionPublisher>();
            m_Scheduler = GetComponent<Scheduler>();

            m_InputActionDict = new Dictionary<InputType,RoomAction>();
            for(int i = 0; i < m_InputTypes.Count; i++){
                m_InputActionDict.Add(m_InputTypes[i],m_RoomActions[i]);
            }

        }

        private void Start() {

        }

        private void OnEnable() {
            
            if (controls == null) {
                controls = new GameControlMap();
            }

            controls.ActivePlayerControls.SetCallbacks(this);
            controls.ActivePlayerControls.Enable();
        }

        private void OnDisable() {
            controls.ActivePlayerControls.RemoveCallbacks(this);
            controls.ActivePlayerControls.Disable();
        }


        public void OnToggleView(InputAction.CallbackContext context)
        {
            Debug.Log("Selection");
            // m_CameraController.ToggleView();
            if (context.performed){

            }
        }

        public void OnConfirm(InputAction.CallbackContext context)
        {
            // throw new NotImplementedException();
            if (context.performed){
                Command cmd = new InputCommand(this, m_InputActionDict[InputType.Confirm]);
                m_Scheduler.AddCommand(cmd);
            }
        }

        public void OnCycleLeft(InputAction.CallbackContext context)
        {
            if (context.performed){
                Command cmd = new InputCommand(this, m_InputActionDict[InputType.CycleLeft]);
                m_Scheduler.AddCommand(cmd);
            }
        }

        public void OnCycleRight(InputAction.CallbackContext context)
        {
            if (context.performed){
                Command cmd = new InputCommand(this, m_InputActionDict[InputType.CycleRight]);
                m_Scheduler.AddCommand(cmd);
            }
        }
    }
}