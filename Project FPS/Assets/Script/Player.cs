using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int currentHealth = 100;
    public TextMeshProUGUI healthText;
    [SerializeField] private AudioSource hit;
    [SerializeField] private AudioSource dead;
    


    private void Start()
    {
        UpdateHealthText();

    }
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Killer"))
        {
            TakeDamage(50);
            hit.Play();
            UpdateHealthText();
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            dead.Play();
            StartCoroutine(LoadDelay());

        }
    }

    void UpdateHealthText()
    {
        healthText.text = "" + currentHealth;
    }

    IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(1);
    }
    
}


