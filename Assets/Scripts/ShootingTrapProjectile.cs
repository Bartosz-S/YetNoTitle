using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingTrapProjectile : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.TryGetComponent<HealthSystem>(out HealthSystem layerHealthSystem)) {
            HealthSystem playerHealthSystem = collision.gameObject.GetComponent<HealthSystem>();
            playerHealthSystem.TakeDamage(10);
        };
        Destroy(gameObject);

    }


}
