using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
    [SerializeField] private Vector3 SpawnPoint;
    [SerializeField] private PlayerReferenceContainer container = null;
    private PlayerInput PlayInput = null;

    private void Awake()
    {
        PlayInput = container.GetComponent<PlayerInput>();
        RespawnPlayer();
    }

    [ContextMenu("Kill player")]
    public void KillPlayer()
    {
        TakeDamage(maxHealthPoints);
    }
    [ContextMenu("Respawn player")]
    public void RespawnPlayer()
    {
        if (!container.PlayersInput.enabled)
        {
            container.PlayersInput.EnableControls();
        }
        TakeHealing(maxHealthPoints);
    }
    [ContextMenu("Check HP")]
    public void CheckPlayerHP()
    {
        Debug.Log("HP: " + HealthPoints);
    }
}
