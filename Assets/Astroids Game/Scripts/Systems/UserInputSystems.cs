using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UserInput.Components;

namespace UserInput.Systems
{
    public partial class UserInputSystems : SystemBase
    {
        private UserControls _userControls;

        private float2 _moveInput;
        private bool _moveAction;
        private bool _shootAction;

        protected override void OnCreate()
        {
            _userControls = new UserControls();

            _userControls.Playeractionmap.Moveaction.started += MoveInput;
            _userControls.Playeractionmap.Moveaction.performed += MoveInput;
            _userControls.Playeractionmap.Moveaction.canceled += MoveInput;

            _userControls.Playeractionmap.Shootaction.started += ShootInput;
            _userControls.Playeractionmap.Shootaction.performed += ShootInput;
            _userControls.Playeractionmap.Shootaction.canceled += ShootInput;
        }

        protected override void OnStartRunning()
        {
            _userControls.Enable();
        }

        protected override void OnStopRunning()
        {
            _userControls.Disable();
        }

        private void MoveInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            _moveInput = obj.ReadValue<Vector2>();
            _moveAction = _moveInput.x != 0 || _moveInput.y != 0;
        }

        private void ShootInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            _shootAction = obj.ReadValue<float>() > 0.01;
        }

        protected override void OnUpdate()
        {
            Entities.ForEach(
                (ref InputMoveData inputData, ref InputShootData shootData) =>
                {
                    inputData.Move = _moveInput;
                    inputData.MoveAction = _moveAction;
                    shootData.ShootAction = _shootAction;
                }).WithoutBurst().Run();
        }
    }
}