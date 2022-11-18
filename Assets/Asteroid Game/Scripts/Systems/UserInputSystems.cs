using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public partial class UserInputSystems: SystemBase
{
    private PlayerControls _playerControls;

    private float2 _moveVector;
    private bool _moveAction;

    protected override void OnCreate()
    {
        _playerControls = new PlayerControls();

        _playerControls.Playeractionmap.Moveaction.started += InputMove;
        _playerControls.Playeractionmap.Moveaction.performed += InputMove;
        _playerControls.Playeractionmap.Moveaction.canceled += InputMove;
    }

    protected override void OnStartRunning()
    {
        _playerControls.Enable();
    }

    protected override void OnStopRunning()
    {
        _playerControls.Disable();
    }

    private void InputMove(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _moveVector = obj.ReadValue<Vector2>();
        _moveAction = _moveVector.x != 0 || _moveVector.y != 0;
    }

    protected override void OnUpdate()
    {
        Entities.ForEach((ref InputData inputData) =>
        {
            inputData.MoveVector = _moveVector;
            inputData.MoveAction = _moveAction;
        }).WithoutBurst().Run();
    }
}
