﻿using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UserInput.Components;

namespace UserInput.Systems
{
    public class UserInputSystems: ComponentSystem
    {
        private EntityQuery _entityQuery;
        private UserControls _userControls;

        private float2 _moveInput;

        protected override void OnCreate()
        {
            _userControls = new UserControls();

            _userControls.Playeractionmap.Moveaction.started += MoveInput;
            _userControls.Playeractionmap.Moveaction.performed += MoveInput;
            _userControls.Playeractionmap.Moveaction.canceled += MoveInput;

            _userControls.Enable();

            _entityQuery = GetEntityQuery(ComponentType.ReadOnly<InputMoveData>());
        }

        protected override void OnStopRunning()
        {
            _userControls.Disable();
        }

        private void MoveInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            _moveInput = obj.ReadValue<Vector2>();
        }

        protected override void OnUpdate()
        {
            Entities.With(_entityQuery)
                .ForEach((Entity entity, ref InputMoveData inputData) =>
                {
                    inputData.Move = _moveInput;
                });
        }
    }
}