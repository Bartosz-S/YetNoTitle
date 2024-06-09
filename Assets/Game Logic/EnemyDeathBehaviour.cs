using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDeathBehaviour : MonoBehaviour
{
    public static event EventHandler OnAnyEnemyDeath;

    public Sprite deathAnimPrefab; // Reference to the deathAnimation prefab
    public HealthSystem healthSystem;
    public float deathAnimDestroyDelay = 0.5f; // Delay before destroying the deathAnim object



    void Start()
    {
        if (healthSystem != null)
        {
            healthSystem.onHealthChange.AddListener(CheckAndDestroy);
        }
        else
        {
            Debug.LogWarning("HealthSystem is not assigned!");
        }
        EnemyList.Instance.OnEnemyListCreated += Instance_OnEnemyListCreated;

    }

    private void Instance_OnEnemyListCreated(object sender, EventArgs e) {
        gameObject.SetActive(false);
    }

    void CheckAndDestroy()
    {
        if (healthSystem.HealthPoints <= 0)
        {
            if (deathAnimPrefab != null)
            {
                // Create a new GameObject for the death animation
                GameObject deathAnim = new GameObject("DeathAnimation");
                deathAnim.transform.position = transform.position; // Position it at the current object's position

                // Add a SpriteRenderer component and set the sprite
                SpriteRenderer spriteRenderer = deathAnim.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = deathAnimPrefab;

                // Optionally, destroy the death animation GameObject after some delay
                Destroy(deathAnim, deathAnimDestroyDelay);
            }
            OnAnyEnemyDeath?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }
}