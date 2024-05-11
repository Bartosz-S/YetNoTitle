using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTrap : MonoBehaviour
{
    [SerializeField] private float shootingTimer;
    [SerializeField] private GameObject projectile;

    private float timer = 0;

    private void Update() {
        timer += Time.deltaTime;
        if (timer >= shootingTimer) {
            timer = 0;
            Instantiate(projectile, transform.position, Quaternion.identity, transform);
        }
    }
}
