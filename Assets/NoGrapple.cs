using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoGrapple : MonoBehaviour
{

    public UnlocksSO unlocks;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            unlocks.SetGrapplingHook(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            unlocks.SetGrapplingHook(true);
        }
    }
}
