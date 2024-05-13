using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTrap : MonoBehaviour {
    [SerializeField] private float shootingTimer;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] float projectileSpeed;
    [SerializeField] private Transform targetDirection;
    private Vector2 direction;

    private float timer = 0;
    private void Start() {
        direction = targetDirection.position - transform.position;
    }
    private void FixedUpdate() {
        timer += Time.deltaTime;
        if (timer >= shootingTimer) {
            timer = 0;
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity, transform);
            Rigidbody2D rb2D = projectile.GetComponent<Rigidbody2D>();
            rb2D.velocity = direction * projectileSpeed;
        }
    }

    public Vector2 GetDirection() {
        return direction;
    }
}
