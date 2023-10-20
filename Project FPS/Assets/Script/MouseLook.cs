using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private float sensivityX = 8f;
    [SerializeField] private float sensivityY = 0.5f;
    private float mouseX, MouseY;

    [SerializeField] private Transform playerCamera;
    [SerializeField] private float xClamp = 85f;
    private float xRotation = 0f;


    private void Update()
    {
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;
    }


    public void ReceiveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x*sensivityX;
        MouseY = mouseInput.y*sensivityY;
        
    }

}
