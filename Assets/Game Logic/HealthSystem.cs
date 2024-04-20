using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealthPoints;
    private int healthPoints;
    private bool isAlive = true;

    private void Awake()
    {
        healthPoints = maxHealthPoints;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(healthPoints);
    }

    public void TakeDamage(int damageValue)
    {
        if (healthPoints - damageValue > 0)
        {
            healthPoints -= damageValue;
            Debug.LogWarning("You took damage! Your hp: " + healthPoints);
        }
        else
        {
            healthPoints = 0;
            isAlive = false;
        }
    }

    public void TakeHealing(int healingValue)
    {
        if (healthPoints + healingValue < maxHealthPoints)
        {
            healthPoints += healingValue;
        }
        else
        {
            healthPoints = maxHealthPoints;
        }
    }

    public bool GetIsAlive()
    {
        return isAlive;
    }

    [ContextMenu("Take 10 damage")]
    void Take10Damage()
    {
        TakeDamage(10);
        Debug.Log(healthPoints);
    }
    [ContextMenu("Heal 10 damage")]
    void Heal10Damage()
    {
        TakeHealing(10);
        Debug.Log(healthPoints);
    }
}




