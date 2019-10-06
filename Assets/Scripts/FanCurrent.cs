using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanCurrent : MonoBehaviour
{

    BoxCollider collider;
    CharacterController controller;
    private bool levitation;
    public Vector3 fanVelocity;

    private void Start()
    {
        levitation = false;
        collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            controller = other.GetComponent<CharacterController>();
            //controller.Move(fanVelocity);
            levitation = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levitation = false;
        }
    }

    private void FixedUpdate()
    {
        if (levitation)
        {
            controller.Move(fanVelocity * Time.fixedDeltaTime);
        }
    }
}
