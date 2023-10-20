using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
#pragma warning disable 649

    [SerializeField] private Movement movement;
    [SerializeField] private MouseLook _mouseLook;
    
    private PlayerControl controls;
    private PlayerControl.GroundMovementActions groundMovement;

    private Vector2 horizontalInput;
    private Vector2 mouseInput;

    private void Awake()
    {
        controls = new PlayerControl();
        groundMovement = controls.GroundMovement;
        
        //gorundMovement.[action].performed += context => do something
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        groundMovement.Jump.performed += _ => movement.OnJumpPressed();

        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }

    private void Update()
    {
        movement.ReceiveInput(horizontalInput);
        _mouseLook.ReceiveInput(mouseInput);
    }

    private void OnEnable()
    {
        
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
