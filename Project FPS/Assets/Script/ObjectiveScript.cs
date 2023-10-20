using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveScript : MonoBehaviour
{
    public TextMeshProUGUI taskText;
    [SerializeField] private GameObject objectItem;
    [SerializeField] private GameObject taskObject;
    private bool isReceivable = false;
    public static int taskCount = 0;
    [SerializeField] private GameObject enemy;


    [SerializeField] private Collider bookPlace;

    private void Start()
    {
        taskObject.SetActive(false);
        taskText.text = "Kitabı Bul ";
        enemy.SetActive(false);
    }

    private void Update()
    {
        if (isReceivable && Input.GetKeyDown(KeyCode.E))
        {
            ReceivableItem();
            taskCount++;

        }
        TaskManager();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isReceivable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isReceivable = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))  
        {
            
            taskObject.SetActive(true);
            taskCount++;
            
        }
    }

    private void ReceivableItem()
    {
        objectItem.SetActive(false);
    }

    private void TaskManager()
    {

        if (taskCount == 1)
        {
            taskText.text = "Kitabı Mezara Taşı";

        }
        if (taskCount==2)
        {
            taskText.text = "KAÇ";
            enemy.SetActive(true);
        }

    }
}

