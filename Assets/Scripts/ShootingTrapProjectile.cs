using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingTrapProjectile : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.TryGetComponent<PlayerHealthSystem>(out PlayerHealthSystem layerHealthSystem)) {
            PlayerHealthSystem playerHealthSystem = collision.gameObject.GetComponent<PlayerHealthSystem>();
            playerHealthSystem.TakeDamage(10);
        };
        Destroy(gameObject);

    }


}
