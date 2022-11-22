using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class UserInputSystem : SystemBase
{
    private PlayerControls _playerControls;

    private float2 _moveVector;
    private bool _moveAction;
    private bool _shootAction;

    protected override void OnCreate()
    {
        _playerControls = new PlayerControls();

        _playerControls.Playeractionmap.Moveaction.started += InputMove;
        _playerControls.Playeractionmap.Moveaction.performed += InputMove;
        _playerControls.Playeractionmap.Moveaction.canceled += InputMove;

        _playerControls.Playeractionmap.Shootaction.started += InputShoot;
        _playerControls.Playeractionmap.Shootaction.performed += InputShoot;
        _playerControls.Playeractionmap.Shootaction.canceled += InputShoot;
    }



    protected override void OnStartRunning()
    {
        _playerControls.Enable();
    }

    protected override void OnStopRunning()
    {
        _playerControls.Disable();
    }

    private void InputMove(InputAction.CallbackContext obj)
    {
        _moveVector = obj.ReadValue<Vector2>();
        _moveAction = _moveVector.x != 0 || _moveVector.y != 0;
    }

    private void InputShoot(InputAction.CallbackContext obj)
    {
        _shootAction = obj.ReadValue<float>() > 0;
    }

    protected override void OnUpdate()
    {
        Entities.ForEach((ref InputData inputData) =>
        {
            inputData.MoveVector = _moveVector;
            inputData.MoveAction = _moveAction;
            inputData.ShootAction = _shootAction;
        }).WithoutBurst().Run();
    }
}
