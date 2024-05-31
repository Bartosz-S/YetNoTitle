using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingTrapProjectile : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemies") || collision.gameObject.CompareTag("Projectiles"))
        {
            // Ignore future collisions between this collider and the collided object's collider
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        else
        {
            if(collision.gameObject.TryGetComponent<PlayerHealthSystem>(out PlayerHealthSystem layerHealthSystem)) {
                PlayerHealthSystem playerHealthSystem = collision.gameObject.GetComponent<PlayerHealthSystem>();
                playerHealthSystem.TakeDamage(10);
            };
        Destroy(gameObject);

        }

    }


}
