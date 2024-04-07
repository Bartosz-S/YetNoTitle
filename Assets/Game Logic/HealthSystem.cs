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

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage(int damage)
    {
        if (healthPoints - damage > 0)
        {
            healthPoints -= damage;
        }
        else
        {
            healthPoints = 0;
            isAlive = false;
        }
    }

    public void takeHealing(int healing)
    {
        if (healthPoints + healing < maxHealthPoints)
        {
            healthPoints += healing;
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
        takeDamage(10);
        Debug.Log(healthPoints);
    }
    [ContextMenu("Heal 10 damage")]
    void Heal10Damage()
    {
        takeHealing(10);
        Debug.Log(healthPoints);
    }
}
