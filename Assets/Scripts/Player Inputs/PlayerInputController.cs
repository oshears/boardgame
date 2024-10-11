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

    // [RequireComponent(typeof(Scheduler))]
    // [RequireComponent(typeof(InputPublisher))]
    public class PlayerInputController : Controller, IActivePlayerControlsActions, IPublisher<InputType>
    {

        private GameControlMap controls;   

        Publisher<InputType> m_InputPublisher;

        public Publisher<InputType> InputPublisher { get { return m_InputPublisher;}}

        void Awake(){
            m_InputPublisher = new Publisher<InputType>();
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

        public void Publish(InputType type){
            m_InputPublisher.Publish(type);
        }

        public void AddListener(Action<InputType> func){
            m_InputPublisher.AddListener(func);
        }

        public void RemoveListener(Action<InputType> func){
            m_InputPublisher.RemoveListener(func);
        }


        public void OnToggleView(InputAction.CallbackContext context)
        {
            // m_CameraController.ToggleView();
            if (context.performed){
                Publish(InputType.ToggleMenu);
            }
        }

        public void OnConfirm(InputAction.CallbackContext context)
        {
            // throw new NotImplementedException();
            if (context.performed){
                Publish(InputType.Confirm);
            }
        }

        public void OnCycleLeft(InputAction.CallbackContext context)
        {
            if (context.performed){
                Publish(InputType.CycleLeft);
            }
        }

        public void OnCycleRight(InputAction.CallbackContext context)
        {
            if (context.performed){
                Publish(InputType.CycleRight);
            }
        }

        public void OnBack(InputAction.CallbackContext context)
        {
            if (context.performed){
                Publish(InputType.Back);
            }
        }

        public void OnExecute(InputAction.CallbackContext context)
        {
            if (context.performed){
                Publish(InputType.Execute);
            }
        }

        public void OnPassTurn(InputAction.CallbackContext context)
        {
            if (context.performed){
                Publish(InputType.PassTurn);
            }
        }
    }
}