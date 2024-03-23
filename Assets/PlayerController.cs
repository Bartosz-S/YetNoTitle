using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Delayed] private float movementSpeed = 10;
    private Vector2 movementInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * movementSpeed * Time.deltaTime);
    }

    public void OnMovement(InputAction.CallbackContext context) => movementInput = context.ReadValue<Vector2>();
}
