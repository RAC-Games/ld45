﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(GrapplingHook))]
public class PickUp : MonoBehaviour
{
    FlashlightToggle flashlight;
    GrapplingHook grapplingHook;
    FirstPersonController fpc;
    public GameObject hookObject;
    public UnlocksSO Unlocks;
    public GameObject CrossHair;

    void Start()
    {
        flashlight = GetComponentInChildren<FlashlightToggle>();
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

        Unlocks.OnFlashlightChanged.AddListener(() =>
        {
            UpdateFlashlight();
        });
        UpdateDoubleJump();
        UpdateGrapplingHook();
        UpdateFlashlight();


    }

    void UpdateGrapplingHook()
    {
        if (Unlocks.GrapplingHook)
        {
            grapplingHook.enabled = true;
            hookObject.SetActive(true);
            CrossHair.SetActive(true);
        }
        else
        {
            grapplingHook.enabled = false;
            CrossHair.SetActive(false);
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

    private void UpdateFlashlight()
    {
        if (Unlocks.Flashlight)
        {
            
            flashlight.enabled = true;

        }
        else
        {
            flashlight.enabled = false;

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
            if (other.CompareTag("Flashlight"))
            {
                Unlocks.Flashlight = true;
            }
            other.gameObject.SetActive(false);
        }
    }
}
