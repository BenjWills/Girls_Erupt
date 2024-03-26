using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWeek : MonoBehaviour
{
    private InGameMenuSettings igMenuSettings;

    private void Start()
    {
        igMenuSettings = GameObject.Find("Menu").GetComponent<InGameMenuSettings>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Triggr Entered");
            igMenuSettings.isSunday = false;
        }
    }
}
