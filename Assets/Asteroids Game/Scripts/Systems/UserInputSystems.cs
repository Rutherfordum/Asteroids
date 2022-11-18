using Asteroid.ComponentData;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroid.Systems
{
    public class UserInputSystems : ComponentSystem
    {
        private EntityQuery _entityQuery;
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

            _userControls.Playeractionmap.ShootAction.started += ShootInput;
            _userControls.Playeractionmap.ShootAction.performed += ShootInput;
            _userControls.Playeractionmap.ShootAction.canceled += ShootInput;

            _entityQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>());
        }

        protected override void OnStartRunning()
        {
            _userControls.Enable();
        }

        protected override void OnStopRunning()
        {
            _userControls.Disable();
        }

        private void MoveInput(InputAction.CallbackContext obj)
        {
            _moveInput = obj.ReadValue<Vector2>();
            _moveAction = _moveInput.x != 0 || _moveInput.y != 0;
        }

        private void ShootInput(InputAction.CallbackContext obj)
        {
            _shootAction = obj.ReadValue<float>() > 0;
        }

        protected override void OnUpdate()
        {
            Entities.With(_entityQuery)
                .ForEach((Entity entity, ref InputData inputData) =>
                {
                    inputData.Move = _moveInput;
                    inputData.MoveAction = _moveAction;
                    inputData.ShootAction = _shootAction;
                });
        }
    }
}