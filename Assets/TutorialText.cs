using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class TutorialText : MonoBehaviour
{
    public GameObject text;
    public GameObject[] otherTexts;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            foreach(GameObject t in otherTexts)
            {
                t.SetActive(false);
            }
            text.SetActive(true);
            this.GetComponent<Collider>().enabled = false;
            StartCoroutine("Deactivate");
        }
    }

    private void Update()
    {
        if (CrossPlatformInputManager.GetButton("Submit") && text.activeSelf)
        {
            
            text.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(5);
        
        text.GetComponent<Animator>().SetTrigger("Off");

    }

}
