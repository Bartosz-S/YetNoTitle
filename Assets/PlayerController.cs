using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public enum PlayerNumber
    {
        [HideInInspector]
        None,
        Player1,
        Player2,
    }

    [SerializeField] private float movementSpeed;
    [SerializeField] private PlayerNumber playerNumber = PlayerNumber.Player1;

    private Controls controls;
    private InputAction moveInput;
    private InputAction actionInput;

    private Vector2 MovementInput => moveInput.ReadValue<Vector2>();

    private void Awake()
    {
        controls = new Controls();
        controls.Enable();
        SetPlayer(playerNumber);
    }

    private void OnEnable()
    {
        ConnectActions();
    }

    private void OnDisable()
    {
        DisconnectActions();
    }

    private void Update()
    {
        transform.Translate(movementSpeed * Time.deltaTime * new Vector2(MovementInput.x, MovementInput.y));
    }

    private void OnInteraction(InputAction.CallbackContext context) => Debug.LogWarning("Action button pressed!");

    private void ConnectActions()
    {
        if(actionInput != null)
            actionInput.performed += OnInteraction;
    }

    private void DisconnectActions()
    {
        if (actionInput != null)
            actionInput.performed -= OnInteraction;
    }

    public void SetPlayer(PlayerNumber playerNumber)
    {
        this.playerNumber = playerNumber;
        DisconnectActions();
        switch (playerNumber)
        {
            case PlayerNumber.Player1:
                actionInput = controls.Gameplay.InteractionP1;
                moveInput = controls.Gameplay.MoveP1;
                break;
            case PlayerNumber.Player2:
                actionInput = controls.Gameplay.InteractionP2;
                moveInput = controls.Gameplay.MoveP2;
                break;
        }
        ConnectActions();
    }
}
