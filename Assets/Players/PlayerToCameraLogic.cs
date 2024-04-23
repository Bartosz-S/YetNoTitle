using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToCamera : MonoBehaviour
{
    private Camera mainCamera;

    public void Start()
    {
        mainCamera = Camera.main;
        mainCamera.enabled = true;
    }

    public void Update()
    {
        PlayersOutOfBondsCheck();
    }

    void PlayersOutOfBondsCheck()
    {
        if(Math.Abs(transform.position.y*1.5) >= mainCamera.orthographicSize * mainCamera.aspect
            || (Math.Abs(transform.position.x)/(mainCamera.orthographicSize * mainCamera.aspect)) >= mainCamera.aspect)
        {
            Debug.LogWarning("You're out of bonds!");
            StopPlayer();
        }
    }

    void StopPlayer()
    {
        
    }
}
