using UnityEngine;
using UnityEngine.InputSystem;

namespace StarterAssets
{
    public class UICanvasControllerInput : MonoBehaviour
    {

        [Header("Output")]
        public StarterAssetsInputs starterAssetsInputs;

        public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
            starterAssetsInputs.MoveInput(virtualMoveDirection);
        }

        public void VirtualLookInput(Vector2 virtualLookDirection)
        {
            starterAssetsInputs.LookInput(virtualLookDirection);
        }

        public void VirtualJumpInput(bool virtualJumpState)
        {
            starterAssetsInputs.JumpInput(virtualJumpState);
        }

        public void VirtualSprintInput(bool virtualSprintState)
        {
            starterAssetsInputs.SprintInput(virtualSprintState);
        }

        public void VirtualZoomInput(bool virtualZoomState)
        {
            starterAssetsInputs.ZoomInput(virtualZoomState);
        }

        public void VirtualChangeWeaponOneInput(bool virtualChangeWeaponOneState)
        {
            starterAssetsInputs.ChangeWeaponOneInput(virtualChangeWeaponOneState);
        }

        public void VirtualChangeWeaponTwoInput(bool virtualChangeWeaponTwoState)
        {
            starterAssetsInputs.ChangeWeaponTwoInput(virtualChangeWeaponTwoState);
        }

        public void VirtualChangeWeaponThreeInput(bool virtualChangeWeaponThreeState)
        {
            starterAssetsInputs.ChangeWeaponThreeInput(virtualChangeWeaponThreeState);
        }

        public void VirtualScrollInput(float virtualScrollDirection)
        {
            starterAssetsInputs.ScrollInput(virtualScrollDirection);
        }
    }

}
