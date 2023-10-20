using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #pragma warning disable 649
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float speed = 6f;
    private Vector2 horizontalInput;
    [SerializeField] private float sprint = 10f;
    private float currentSpeed = 6f;
    
    public float runDuration = 3.0f;
    private float currentRunTime = 0.0f;


    [SerializeField] private float jumpHeight = 4;
    bool jump;
    
    [SerializeField] private float gravity = -9.81f;
    private Vector3 veritcalVelocity = Vector3.zero;
    [SerializeField] private LayerMask groundMask;
    bool isGrounded;
    bool isRunning = false;

    [SerializeField] private AudioSource breatheSound;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, 1.0f, groundMask);
        if (isGrounded)
        {
            veritcalVelocity.y = 0;
        }
        
        Vector3 horizontalVelocity =
            (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        _controller.Move(horizontalVelocity * Time.deltaTime);

        if (jump)
        {
            if (isGrounded)
            {
                veritcalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }

            jump = false;
        }

        veritcalVelocity.y += gravity * Time.deltaTime;
        _controller.Move(veritcalVelocity * Time.deltaTime);


        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (!isRunning && currentRunTime < runDuration)
            {
                speed = sprint;
                isRunning = true;
            }
        }
        
        if (isRunning)
        {
            currentRunTime += Time.deltaTime;
            if (currentRunTime >= runDuration)
            {
                isRunning = false;
                currentRunTime = 0.0f;
                speed = currentSpeed;
                breatheSound.Play();
            }
        }



    }

    public void ReceiveInput(Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
    }

    public void OnJumpPressed()
    {
        jump = true;
    }

}
