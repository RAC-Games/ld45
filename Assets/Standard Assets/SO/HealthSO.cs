using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Health", menuName = "Health", order = 1)]
public class HealthSO : ScriptableObject
{
    [SerializeField] private float health;
    public float MaxHealth;

    private void OnEnable()
    {
        Reset();
    }
    public void DoDamage(float amount)
    {
        health -= amount;
        if (health < 0) 
            OnPlayerDeath.Invoke();
    }

    public void Reset() => health = MaxHealth;

    public UnityEvent OnPlayerDeath = new UnityEvent();
}
