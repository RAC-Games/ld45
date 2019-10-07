using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    private bool goLeft;
    private bool goRight;
    public bool goRightAtStart;
    public bool horizontal;
    public float platformSpeed;
    private bool moving;
    public float maxX, minX, maxZ, minZ;

    private void Start()
    {
        moving = true;
        //StartCoroutine("doMovement");
        //cycleStartTime = Time.time;
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

    /*IEnumerator doMovement()
    {
        while (true)
        {
            if (moving)
            {
                goRight = !goRight;
                goLeft = !goLeft;
                yield return new WaitForSeconds(cycleTime);
            }
            yield return new WaitForSeconds(0);
        }

    }*/

    void TurnAround()
    {
        if (transform.localPosition.x > maxX || transform.localPosition.x < minX)
        {
            goRight = !goRight;
            goLeft = !goLeft;
        }

        if (transform.localPosition.z > maxZ || transform.localPosition.z < minZ)
        {
            goRight = !goRight;
            goLeft = !goLeft;
        }

    }
}
