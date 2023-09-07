using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public float scroll;
        public bool jump;
        public bool sprint;
        public bool zoom;
        public bool changeWeaponOne;
        public bool changeWeaponTwo;
        public bool changeWeaponThree;

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
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

        public void OnZoom(InputValue value)
        {
            ZoomInput(value.isPressed);
        }

        public void OnChangeWeaponOne(InputValue value)
        {
            ChangeWeaponOneInput(value.isPressed);
        }

        public void OnChangeWeaponTwo(InputValue value)
        {
            ChangeWeaponTwoInput(value.isPressed);
        }

        public void OnChangeWeaponThree(InputValue value)
        {
            ChangeWeaponThreeInput(value.isPressed);
        }

        public void OnScroll(InputValue value)
        {
            ScrollInput(value.Get<float>());
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

        public void ZoomInput(bool newZoomState)
        {
            zoom = newZoomState;
        }

        public void ChangeWeaponOneInput(bool newChangeWeaponOneState)
        {
            changeWeaponOne = newChangeWeaponOneState;
        }
        public void ChangeWeaponTwoInput(bool newChangeWeaponTwoState)
        {
            changeWeaponTwo = newChangeWeaponTwoState;
        }
        public void ChangeWeaponThreeInput(bool newChangeWeaponThreeState)
        {
            changeWeaponThree = newChangeWeaponThreeState;
        }

        public void ScrollInput(float newScrollState)
        {
            scroll = newScrollState;
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