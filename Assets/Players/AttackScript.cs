using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private List<Collider2D> attackedEnemies = new List<Collider2D>();
    private List<HealthSystem> enemiesHPs = new List<HealthSystem>();

    [SerializeField] private int damageValue = 10;

    private void Interaction()
    {
        Attack();
    }

    public void Attack()
    {
        foreach (GameObject gameObjects in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemiesHPs.Add(gameObjects.GetComponent<HealthSystem>());
        }
        foreach (Collider2D enemies in attackedEnemies)
        {
            //enemiesHPs.Add(enemies.gameObject.GetComponent<HealthSystem>());
        }
        foreach (HealthSystem hp in enemiesHPs)
        {
            if (hp.IsAlive == false) continue;

            hp.TakeDamage(damageValue);
        }
        enemiesHPs.Clear();
    }
}

