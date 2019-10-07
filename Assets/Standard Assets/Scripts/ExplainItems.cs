using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplainItems : MonoBehaviour
{
    public GameObject flashlightText;
    public GameObject hookText;
    public GameObject jumpText;
    GameObject text;

    public void Flashlight()
    {
        flashlightText.SetActive(true);
        text = flashlightText;
        StartCoroutine("Deactivate");
    }

   public void GrapplingHook()
    {
        hookText.SetActive(true);
        text = hookText;
        StartCoroutine("Deactivate");
    }

    public void DoubleJump()
    {
        jumpText.SetActive(true);
        text = jumpText;
        StartCoroutine("Deactivate");
    }



    IEnumerator Deactivate()
    {
        print("started");
        yield return new WaitForSeconds(5);

        flashlightText.GetComponent<Animator>().SetTrigger("Off");
        hookText.GetComponent<Animator>().SetTrigger("Off");
        jumpText.GetComponent<Animator>().SetTrigger("Off");

    }
}
