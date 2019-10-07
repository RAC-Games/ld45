using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    private bool goLeft;
    private bool goRight;
    public bool goRightAtStart;
    public float cycleTime;
    private float cycleStartTime;
    public bool horizontal;
    public float platformSpeed;
    private bool moving;

    private void Start()
    {
        moving = true;
        cycleStartTime = Time.time;
        if (goRightAtStart)
        {
            goRight = true;
        } else
        {
            goLeft = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Anchor"))
        {
            moving = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Anchor"))
        {
            moving = true;
        }
    }

    private void Update()
    {
        if (!moving)
        {
            return;
        }
        TurnAround();
        if (goLeft)
        {
            if (horizontal)
            {
                transform.Translate(new Vector3(-Time.deltaTime * platformSpeed, 0, 0));
            } else
            {
                transform.Translate(new Vector3(0, 0, -Time.deltaTime * platformSpeed));
            }
        } else
        {
            if (horizontal)
            {
                transform.Translate(new Vector3(Time.deltaTime * platformSpeed, 0, 0));
            } else
            {
                transform.Translate(new Vector3(0, 0, Time.deltaTime * platformSpeed));
            }
        }
    }

    void TurnAround()
    {
        if (Time.time > cycleStartTime + cycleTime)
        {
            cycleStartTime = Time.time;
            goRight = !goRight;
            goLeft = !goLeft;
        }
    }
}
