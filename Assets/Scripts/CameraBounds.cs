using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Cinemachine.Utility;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;
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
        Camera.main.transform.position = new Vector3(0, 0, Camera.main.transform.position.z);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        TargetGroupUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        TargetGroupUpdate();
        SetPosition(player1);
        SetPosition(player2);
    }
    private void SetPosition(Transform player) {
        Vector3 playerPosition = player.position;
        playerPosition.x = Mathf.Clamp(playerPosition.x, screenXmin , screenXmax);
        playerPosition.y = Mathf.Clamp(playerPosition.y, screenYmin , screenYmax);
        player.position = playerPosition;
    }

    private void TargetGroupUpdate() {
        screenXmin = targetGroup.position.x + screenBounds.x;
        screenXmax = targetGroup.position.x + (screenBounds.x * -1);
        screenYmin = targetGroup.position.y + screenBounds.y;
        screenYmax = targetGroup.position.y + (screenBounds.y * -1);
    }
}   

