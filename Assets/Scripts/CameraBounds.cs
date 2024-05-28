using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Cinemachine.Utility;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;
    [SerializeField] private BoxCollider2D player1BC2D;
    [SerializeField] private BoxCollider2D player2BC2D;
    [SerializeField] private Transform targetGroup;
    [SerializeField] private CinemachineVirtualCamera cinemachineCamera;

    private CinemachineFramingTransposer cinemachineFramingTransposer;
    private Vector3 screenBounds;
    float screenXmin;
    float screenXmax;
    float screenYmin;
    float screenYmax;

    private void Start() {
        cinemachineFramingTransposer = cinemachineCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        float cameraScopeRatio =
            cinemachineFramingTransposer.m_MaximumFOV / cinemachineFramingTransposer.m_MinimumFOV;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        screenBounds.x = screenBounds.x * cameraScopeRatio;
        screenBounds.y = screenBounds.y * cameraScopeRatio;
        screenBounds.z = screenBounds.z * cameraScopeRatio;
        TargetGroupUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        TargetGroupUpdate();
        SetPosition(player1, player1BC2D);
        SetPosition(player2, player1BC2D);
    }
    private void SetPosition(Transform player, BoxCollider2D playerBC2D) {
        Vector3 playerPosition = player.position;
        playerPosition.x = Mathf.Clamp(playerPosition.x, screenXmin + playerBC2D.size.x, screenXmax - playerBC2D.size.x);
        playerPosition.y = Mathf.Clamp(playerPosition.y, screenYmin - playerBC2D.size.y, screenYmax - playerBC2D.size.y);
        player.position = playerPosition;
    }

    private void TargetGroupUpdate() {
        screenXmin = targetGroup.position.x + screenBounds.x;
        screenXmax = targetGroup.position.x + (screenBounds.x * -1);
        screenYmin = targetGroup.position.y + screenBounds.y;
        screenYmax = targetGroup.position.y + (screenBounds.y * -1);
    }
}   

