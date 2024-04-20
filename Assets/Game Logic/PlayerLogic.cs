using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private bool isPlayerAlive = true;
    HealthSystem PlayerHealthSystem;
    [SerializeField] private PlayerController controller = null;

    private void Awake()
    {
        PlayerHealthSystem = gameObject.GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        IsPlayerAliveCheck(PlayerHealthSystem.GetIsAlive());
    }

    public void IsPlayerAliveCheck(bool isPlayerAlive)
    {
        if (!isPlayerAlive)
        {
            KillPlayer();
        }
    }

    [ContextMenu("Kill player")]
    public void KillPlayer()
    {
        if (isPlayerAlive)
        {
            isPlayerAlive = false;
            controller.DisconnectActions();
        }
    }
    [ContextMenu("Respawn player")]
    public void RespawnPlayer()
    {
        if(!isPlayerAlive)
        {
            isPlayerAlive = true;
            controller.ConnectActions();
        }
    }
}
