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
    public UnlocksSO Unlocks;

    void Start()
    {
        grapplingHook = GetComponent<GrapplingHook>();
        fpc = GetComponent<FirstPersonController>();
        grapplingHook.enabled = false;

        Unlocks.OnGrapplingHookChanged.AddListener(() =>
        {
            UpdateGrapplingHook();
        });

        Unlocks.OnDoubleJumpChanged.AddListener(()=>
        {
            UpdateDoubleJump();
        });
        UpdateDoubleJump();
        UpdateGrapplingHook();
    }

    void UpdateGrapplingHook()
    {
        if (Unlocks.GrapplingHook)
        {
            grapplingHook.enabled = true;
            hookObject.SetActive(true);
        }
        else
        {
            grapplingHook.enabled = false;
            hookObject.SetActive(false);
        }
    }

    void UpdateDoubleJump()
    {
        if (Unlocks.DoubleJump)
        {
            fpc.doubleJump = true;

        }
        else
        {
            fpc.doubleJump = false;

        }
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (CrossPlatformInputManager.GetButtonDown("Use"))
        {
            if (other.CompareTag("Hook"))
            {
                    Unlocks.GrapplingHook = true;
            }
            if (other.CompareTag("Shoes"))
            {
                Unlocks.DoubleJump = true;
            }
            other.gameObject.SetActive(false);
        }
    }
}
