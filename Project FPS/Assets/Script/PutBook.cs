using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PutBook : MonoBehaviour
{
    [SerializeField] private GameObject taskObject;


    

    private void Start()
    {
        taskObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))  
        {
            
                ReceivableItem();
                ObjectiveScript.taskCount++;
            
        }
    }

    private void ReceivableItem()
    {
        taskObject.SetActive(true);

    }
}
