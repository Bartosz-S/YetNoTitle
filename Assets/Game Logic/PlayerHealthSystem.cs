using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
    [SerializeField] private Vector3 SpawnPoint;
    [SerializeField] private PlayerInput Controller = null;

    private void Awake()
    {
        RespawnPlayer();
        onHealthChange.AddListener(IfHealthChanged);
    }

    private void IfHealthChanged()
    {
        if (!IsAlive)
        {
            KillPlayer();
        }
    }

    [ContextMenu("Kill player")]
    public void KillPlayer()
    {
        if(Controller.isActiveAndEnabled) 
        {
            Controller.DisableControls();
        }
    }
    [ContextMenu("Respawn player")]
    public void RespawnPlayer()
    {
        if (!Controller.isActiveAndEnabled)
        {
            Controller.EnableControls();
        }
        HealthPoints = maxHealthPoints;
    }
    [ContextMenu("Check HP")]
    public void CheckPlayerHP()
    {
        Debug.Log("HP: " + HealthPoints);
    }
}
