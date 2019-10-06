using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorActivator : MonoBehaviour
{
    public GameObject Player;
    // public GameObject Activator;
    private Rigidbody rigidbody_player;

    //void Awake()
    //{
    //    rigidbody_player = Player.gameObject.GetComponent<Rigidbody>();

    //}
    private void OnTriggerEnter(Collider other)
    {
        // Change the cube color to green.
        MeshRenderer meshRend = GetComponent<MeshRenderer>();
        meshRend.material.color = Color.green;
        Debug.Log("Trigger activated");
    }

}
