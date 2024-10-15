using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInput PlayerInput;

    public Vector2 Movement;
    public bool JumpWasPressed;
    public bool JumpIsHeld;
    public bool JumpWasReleased;
    public bool RunIsHeld;

    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _runAction;

    void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();

        _moveAction = PlayerInput.actions["Move"];
        _jumpAction = PlayerInput.actions["Jump"];
        _runAction = PlayerInput.actions["Run"];
    }

    void Update()
    {
        Movement = _moveAction.ReadValue<Vector2>();

        JumpWasPressed = _jumpAction.WasPressedThisFrame();
        JumpIsHeld = _jumpAction.IsPressed();
        JumpWasReleased = _jumpAction.WasReleasedThisFrame();

        RunIsHeld = _jumpAction.IsPressed();
    }
}
