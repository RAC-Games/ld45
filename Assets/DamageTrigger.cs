using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    public float secondsToSurvive;
    void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            var health = other.GetComponent<PlayerHealth>().playerHealth;
            health.DoDamage(health.MaxHealth / secondsToSurvive * Time.fixedDeltaTime);
        }
    }
}
