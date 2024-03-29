using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Delayed] private float movementSpeed;

    private Vector2 movementInput;
    private Controls controls;
    [SerializeField] private Player choosePlayer;
    private enum Player
    {
        None,
        Player1,
        Player2,
    }

    private void Awake()
    {
        switch (choosePlayer)
        {
            case Player.None:
                break;
            case Player.Player1:
                controls = new Controls();
                controls.Enable();
                break;
            case Player.Player2:
                controls = new Controls();
                controls.Enable();
                break;
        }
    }

    private void OnEnable()
    {
        ActivatePlayers();
    }

    private void OnDisable()
    {
        DeactivatePlayers();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementSpeed * Time.deltaTime * new Vector2(movementInput.x, movementInput.y));
    } 

    public void OnMovement(InputAction.CallbackContext context) => movementInput = context.ReadValue<Vector2>();

    public void OnInteraction(InputAction.CallbackContext context) => Debug.LogWarning("Action button pressed!");

    public void ActivatePlayers()
    {
        controls.Gameplay.Enable();
        switch (choosePlayer)
        {
            case Player.Player1:
                controls.Gameplay.InteractionP1.performed += OnInteraction;
                controls.Gameplay.MoveP1.performed += OnMovement;
                break;
            case Player.Player2:
                controls.Gameplay.InteractionP2.performed += OnInteraction;
                controls.Gameplay.MoveP2.performed += OnMovement;
                break;
        }
    }

    public void DeactivatePlayers()
    {
        controls.Gameplay.Disable();
        switch (choosePlayer)
        {
            case Player.Player1:
                controls.Gameplay.InteractionP1.performed -= OnInteraction;
                controls.Gameplay.MoveP1.performed -= OnMovement;
                break;
            case Player.Player2:
                controls.Gameplay.InteractionP2.performed -= OnInteraction;
                controls.Gameplay.MoveP2.performed -= OnMovement;
                break;
        }
    }

}
