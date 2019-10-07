using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Health", menuName = "Health", order = 1)]
public class HealthSO : ScriptableObject
{
    [SerializeField] private float health;
    public float Health { get => health; }
    public float MaxHealth;
    public bool GetDamage = false;
    private void OnEnable()
    {
        Reset();
    }
    bool dead = false;
    public void DoDamage(float amount)
    {
        if (dead) return;
        GetDamage = true;
        health -= amount;

        if (!working)
        {
            working = true;
            disableGetDamage();
        }

        if (health < 0)
        {
            OnPlayerDeath.Invoke();
            dead = true;
        }
    }

    public void Reset()
    {
        health = MaxHealth;
        dead = false;
    }

    public UnityEvent OnPlayerDeath = new UnityEvent();

    bool working = false;
    async void disableGetDamage()
    {
        await Task.Delay(2);
        GetDamage = false;
        working = false;
    }
}
