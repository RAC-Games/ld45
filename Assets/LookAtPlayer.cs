using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public GameObject playerChar;
   

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(playerChar.transform);
        transform.forward *= -1;
    }
}
