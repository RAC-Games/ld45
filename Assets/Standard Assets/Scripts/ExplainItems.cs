using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplainItems : MonoBehaviour
{
    public GameObject flashlightText;
    public GameObject hookText;
    public GameObject jumpText;
    public GameObject text;

    public void Flashlight()
    {
        flashlightText.SetActive(true);
        
    }

   public void GrapplingHook()
    {
        hookText.SetActive(true);
        text = hookText;
    }

    public void DoubleJump()
    {
        jumpText.SetActive(true);
        text = jumpText;
    }



    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(5);

        flashlightText.GetComponent<Animator>().SetTrigger("Off");
        hookText.GetComponent<Animator>().SetTrigger("Off");
        jumpText.GetComponent<Animator>().SetTrigger("Off");

    }
}
