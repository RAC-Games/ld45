using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TutorialText : MonoBehaviour
{
    public GameObject text;

    private void OnTriggerEnter(Collider other)
    {
        print("Collided");
        if (other.CompareTag("Player"))
        {
            text.SetActive(true);
        }
    }

    private void Update()
    {
        
    }

}
