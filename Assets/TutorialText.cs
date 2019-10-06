using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class TutorialText : MonoBehaviour
{
    public GameObject text;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            text.SetActive(true);
        }
    }

    private void Update()
    {
        if ((CrossPlatformInputManager.GetButton("Submit") && text.activeSelf) || (Input.GetKey(KeyCode.E) && text.activeSelf))
        {
            text.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

}
