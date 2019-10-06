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

    private void Start()
    {
        cycleStartTime = Time.time;
        if (goRightAtStart)
        {
            goRight = true;
        } else
        {
            goLeft = true;
        }
    }

    private void Update()
    {
        TurnAround();
        if (goLeft)
        {
            transform.Translate(new Vector3(-Time.deltaTime, 0, 0));
        } else
        {
            transform.Translate(new Vector3(Time.deltaTime, 0, 0));
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
