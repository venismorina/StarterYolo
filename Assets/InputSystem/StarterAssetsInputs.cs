using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using Cinemachine;
using System;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
      
        [HideInInspector]

        public Vector2 move;
        [HideInInspector]

        public Vector2 look;
        [HideInInspector]

        public bool jump;
        [HideInInspector]

        public bool sprint;

   

        [HideInInspector]
        public bool analogMovement;

    
        bool cursorLocked = true;
        bool cursorInputForLook = true;


        public CinemachineFreeLook cam;

        [Header("Look Settings")]
        public float xSpeed = 500f;
        public float ySpeed = 2f;

        [Header("Zoom Settings")]
        public float zoomMin = 30f;
        public float zoomMax = 55f;
        public float zoomSensivity = 8f;


        int x = 0;
        #if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED

        private void Update()
        {

            cam.m_CommonLens = true;
            var fov = cam.m_Lens.FieldOfView;
            fov -= Input.GetAxis("Mouse ScrollWheel") * zoomSensivity;
            fov = Mathf.Clamp(fov, zoomMin, zoomMax);
            cam.m_Lens.FieldOfView = fov;


            if (Input.GetMouseButton(0)){
                 x++;

                 if(x > 200){
                    SetCursorState(true);
                }
            }
            if (Input.GetMouseButton(0) && !cursorLocked && !cursorInputForLook)
            {
                cursorLocked = true;
                cursorInputForLook = true;
                Cursor.visible = false;
                
                cam.m_YAxis.m_MaxSpeed = ySpeed;
                cam.m_XAxis.m_MaxSpeed = xSpeed;


            }
            else if(Input.GetMouseButtonUp(0) && cursorLocked && cursorInputForLook)
            {
                cursorLocked = false;
                cursorInputForLook = false;
                LookInput(Vector2.zero);
                Cursor.visible = true;

                SetCursorState(cursorLocked);

                x = 0;

                cam.m_YAxis.m_MaxSpeed = 0;
                cam.m_XAxis.m_MaxSpeed = 0;
            }
        }

       
        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        public void OnLook(InputValue value)
        {
            if (cursorInputForLook)
            {
                LookInput(value.Get<Vector2>());
            }
        }

        public void OnJump(InputValue value)
        {
            JumpInput(value.isPressed);
        }

        public void OnSprint(InputValue value)
        {
            SprintInput(value.isPressed);
        }
#endif


        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }

        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }

}