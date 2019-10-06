using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{
    public HealthSO playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth.Reset();
        playerHealth.OnPlayerDeath.AddListener(() => {
            GetComponent<FirstPersonController>().Death();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
