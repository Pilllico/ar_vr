using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorBehaviourScript : MonoBehaviour
{
    public GameObject endScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            endScreen.SetActive(true);
        }
    }
}
