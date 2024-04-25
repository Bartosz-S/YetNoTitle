using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private protected int maxHealthPoints;
    private int healthPoints;

    public bool IsAlive => HealthPoints > 0;

    public int HealthPoints
    {
        get { return healthPoints; }
        set
        {
            if(healthPoints != value)
            {
                healthPoints = value;
                onHealthChange.Invoke();
            }
        }
    }

    public UnityEvent onHealthChange = new UnityEvent();

    void Start()
    {
        Debug.Log(HealthPoints);
    }

    public void TakeDamage(int damageValue)
    {
        if (HealthPoints - damageValue > 0)
        {
            HealthPoints -= damageValue;
            Debug.LogWarning("You took damage! Your hp: " + HealthPoints);
        }
        else
        {
            HealthPoints = 0;
        }
    }

    public void TakeHealing(int healingValue)
    {
        if (HealthPoints + healingValue < maxHealthPoints)
        {
            HealthPoints += healingValue;
        }
        else
        {
            HealthPoints = maxHealthPoints;
        }
    }

    [ContextMenu("Kill unit")]
    public void KillUnit()
    {
        TakeDamage(maxHealthPoints);
    }
    [ContextMenu("Respawn unit")]
    public void RespawnUnit()
    {
        TakeHealing(maxHealthPoints);
    }

    [ContextMenu("Take 10 damage")]
    void Take10Damage()
    {
        TakeDamage(10);
        Debug.Log(HealthPoints);
    }
    [ContextMenu("Heal 10 damage")]
    void Heal10Damage()
    {
        TakeHealing(10);
        Debug.Log(HealthPoints);
    }
}




