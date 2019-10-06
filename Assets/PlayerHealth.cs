using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{
    public HealthSO playerHealth;
    public Image damage;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth.Reset();
        playerHealth.OnPlayerDeath.AddListener(() => {
            GetComponent<FirstPersonController>().Death();
        });
    }
    Color oldColor;
    // Update is called once per frame
    void Update()
    {
        if (playerHealth.GetDamage)
        {
        oldColor = damage.color;
        oldColor.a = 1 - playerHealth.Health / playerHealth.MaxHealth;
        damage.color = oldColor;
        }
        else
        {
            if (damage.color.a>Time.deltaTime)
            {
                oldColor = damage.color;
                oldColor.a -= Time.deltaTime;
                damage.color = oldColor;
            }
            
        }
    }
}
