using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class /*ElevatorActivator*/GetFlashlight : MonoBehaviour
{
    public GameObject Lever;
    public GameObject Elevator;
    Animator e_Animator;
    Animator l_Animator;

    private void Update()
    {
        //TODO: fix this!
        print("!!!!!Elevator Activator auskommentiert weil buggy!!!!!!!");
    }

    //public GameObject Player;
    // public GameObject Activator;
    //private Rigidbody rigidbody_player;

    /*void Start()
    {
        e_Animator = Elevator.GetComponent<Animator>();
        l_Animator = Lever.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {

        TriggerLever();
        Debug.Log("Trigger activated");

    }

    private void TriggerLever()
    {
        //play Leversound
        //l_Animator.SetTrigger("LeverMove");
        l_Animator.SetBool("Leverbool", true);
        //wait
        //l_Animator.SetBool("LeverOn", true);
 

    }*/




}
