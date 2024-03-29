﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorActivator : MonoBehaviour
{
    public GameObject Lever;
    public GameObject Elevator;
    Animator e_Animator;
    Animator l_Animator;



    //public GameObject Player;
    // public GameObject Activator;
    //private Rigidbody rigidbody_player;

    void Start()
    {
        e_Animator = Elevator.GetComponent<Animator>();
        l_Animator = Lever.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerLever();
            Debug.Log("Trigger activated");
        }

    }

    private void TriggerLever()
    {
        //play Leversound
        //l_Animator.SetTrigger("LeverMove");
        l_Animator.SetBool("Leverbool", true);
        //wait
        //l_Animator.SetBool("LeverOn", true);
        MoveElevator();
        //play Elevator startsound
        
    }


    private void MoveElevator()
    {
        e_Animator.SetBool("LeverOn", true);
        //play Elevator movesound
    }
    
}

