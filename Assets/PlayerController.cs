using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Delayed] private float movementSpeed = 10;
    
    private Vector2 movementInput;
    private bool isActButtPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * movementSpeed * Time.deltaTime);
        if(isActButtPressed) { Debug.Log("Action button pressed!"); isActButtPressed = false; }
    }

    public void OnMovement(InputAction.CallbackContext context) => movementInput = context.ReadValue<Vector2>();

    public void OnInteraction(InputAction.CallbackContext context) => isActButtPressed = true;
   
    
}
