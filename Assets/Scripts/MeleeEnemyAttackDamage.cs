using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAttackDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<PlayerHealthSystem>(out PlayerHealthSystem playerHealthSystem))
        {
            playerHealthSystem.TakeDamage(10);
        }
        Destroy(gameObject);
    }
}