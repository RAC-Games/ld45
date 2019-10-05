using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(GrapplingHook))]
public class PickUp : MonoBehaviour
{
    GrapplingHook grapplingHook;
    FirstPersonController fpc;
    public GameObject hookObject;

    void Start()
    {
        grapplingHook = GetComponent<GrapplingHook>();
        fpc = GetComponent<FirstPersonController>();
        grapplingHook.enabled = false;
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (CrossPlatformInputManager.GetButtonDown("Use")){
            if (other.CompareTag("Hook"))
            {
                grapplingHook.enabled = true;
                hookObject.SetActive(true);
            }
            if (other.CompareTag("Shoes"))
            {
                fpc.doubleJump = true;
                print("Change Doublejumpbool in other Script! ");
            }
            other.gameObject.SetActive(false);
        }
    }
}
