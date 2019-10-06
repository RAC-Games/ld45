using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideElevator : MonoBehaviour
{
    //in the current state this script clips the player to the elevator, meaning he won't clip through in the options menu.
    //ideally, this would be updated and linked with the FPS main script to make travel smoother
    GameObject Player;


    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }


    private void OnTriggerEnter(Collider other)
    {
        Player.transform.parent = transform;
        Debug.Log("Trigger activated");

    }

    private void OnTriggerExit(Collider other)
    {
        Player.transform.parent = null;
        Debug.Log("Trigger Exited");
    }




}
