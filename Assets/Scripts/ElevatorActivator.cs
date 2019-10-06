using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorActivator : MonoBehaviour
{
    public GameObject Lever;
    public GameObject Elevator;
    Animator e_Animator;
    Animator l_animator



    //public GameObject Player;
    // public GameObject Activator;
    //private Rigidbody rigidbody_player;

    void Awake()
    {
        e_Animator = Elevator.gameObject.GetComponent<Animator>();
        l_Animator = Lever.gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        TriggerLever()
        Debug.Log("Trigger activated");

    }

    private void TriggerLever()
    {
        //play Leversound
        e_Animator.SetTrigger("LeverMove", true);

        MoveElevator()
        //play Elevator startsound
        
    }


    private void MoveElevator()
    {
        e_Animator.SetBool("LeverOn", true);
        //play Elevator movesound
    }
    
}

