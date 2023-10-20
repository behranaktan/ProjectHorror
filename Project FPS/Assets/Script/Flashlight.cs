using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;
    
    [SerializeField] private AudioSource turnOn;
    [SerializeField] private AudioSource turnOff;
    
    private bool isFlashlightOn = false;

    private void Start()
    {
        flashlight.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isFlashlightOn)
            {
                flashlight.SetActive(false);
                isFlashlightOn = false;
                turnOff.Play();
            }
            else
            {
                flashlight.SetActive(true);
                isFlashlightOn = true;
                turnOn.Play();
            }
        }
    }
}

