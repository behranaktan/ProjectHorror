using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpScare : MonoBehaviour
{
    [SerializeField] private GameObject jumpScare;
    [SerializeField]private AudioSource jsSound;

    void Start()
    {
        jumpScare.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jumpScare.SetActive(true);
            StartCoroutine(JumpS());
            jsSound.Play();
        }

    }

    IEnumerator JumpS()
    {
        yield return new WaitForSeconds(0.5f);
        jumpScare.SetActive(false);
    }
}
