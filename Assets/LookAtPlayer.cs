using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private GameObject playerChar;


    private void Start()
    {
        playerChar = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(playerChar.transform);
        transform.forward *= -1;
    }
}
