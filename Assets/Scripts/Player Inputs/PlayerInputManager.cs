using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static GameControlMap;
using OSGames.BoardGame.Generic;

namespace OSGames.BoardGame.Inputs {
    public class PlayerInputManager : MonoBehaviour, IActivePlayerControlsActions
    {

        private GameControlMap controls;   

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

                
            }
        }

        public void OnCycleLeft(InputAction.CallbackContext context)
        {
            if (context.performed){

            }
        }

        public void OnCycleRight(InputAction.CallbackContext context)
        {
            if (context.performed){

            }
        }
    }
}