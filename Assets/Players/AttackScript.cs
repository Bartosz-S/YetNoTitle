using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private List<Collider2D> enemies;

    [SerializeField] private int damageValue;
    [SerializeField] private float attackRange;
    //[SerializeField] private double attackRate;
    

    private int enemyLayer;
    

    private void Awake()
    {
        enemyLayer = LayerMask.NameToLayer("Enemies");
    }

    public void Attack()
    {
        enemies = Physics2D.OverlapCircleAll(transform.position, attackRange).ToList();

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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
