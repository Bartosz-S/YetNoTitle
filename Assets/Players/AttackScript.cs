using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackScript : ActionScript
{
    private List<Collider2D> enemies = new List<Collider2D>();

    [SerializeField] private int damageValue;
    [SerializeField] private double attackRate;
    [SerializeField] private Collider2D AttackField;
    private int enemyLayer;

    public override void Use()
    {
        Attack();
        
    }

    private void Awake()
    {
        enemyLayer = LayerMask.NameToLayer("Enemies");
    }

    public void Attack()
    {
        if (enemies.Count() == 0) return;
        foreach (Collider2D enemies in enemies)
        {
            if(enemies.gameObject.layer != enemyLayer)
            {
                continue;
            }
            else enemies.gameObject.GetComponent<HealthSystem>().TakeDamage(damageValue);

        }
        
        Debug.Log("Attack!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!enemies.Contains(collision)) { enemies.Add(collision); }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (enemies.Contains(collision)) { enemies.Remove(collision); }
    }
}
