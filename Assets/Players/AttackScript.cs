using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private List<Collider2D> enemies;
    private List<HealthSystem> enemiesHPs = new List<HealthSystem>();
    [SerializeField] private int damageValue;

    public void Attack()
    {
        foreach (GameObject gameObjects in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemiesHPs.Add(gameObjects.GetComponent<HealthSystem>());
        }
        foreach (Collider2D enemies in enemies)
        {
            //enemiesHPs.Add(enemies.gameObject.GetComponent<HealthSystem>());
        }
        foreach (HealthSystem hp in enemiesHPs)
        {
            if (hp.IsAlive == false) continue;

            hp.TakeDamage(damageValue);
        }
        enemiesHPs.Clear();

        Debug.Log("Attack!");
    }
}
