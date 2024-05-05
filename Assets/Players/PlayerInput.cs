using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public enum PlayerNumber
    {
        [InspectorName(null)]
        None,
        Player1,
        Player2,
    }

    [SerializeField] private float movementSpeed;
    [SerializeField] private PlayerNumber playerNumber = PlayerNumber.Player1;
    [SerializeField] private PlayerReferenceContainer container;
    [SerializeField] private Rigidbody2D rigidbody2D;

    private Controls controls;
    private InputAction moveInput;
    private InputAction actionInput;

    private Vector2 MovementInput => moveInput.ReadValue<Vector2>();
    
    private void Awake()
    {
        controls = new Controls();
        controls.Enable();
        SetPlayer(playerNumber);
        container.PlayersHealthSystem.onHealthChange.AddListener(OnDeath);
    }

    private void OnDeath()
    {
        if (!container.PlayersHealthSystem.IsAlive)
        {
            controls.Disable();
        }
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
        //previous version with using tranfsorm position
        //transform.Translate(movementSpeed * Time.deltaTime * new Vector2(MovementInput.x, MovementInput.y));
        //New version with using rigidbody to avoid shaking when collision detected
        if (MovementInput != null) {
            Move();
        }
    }

    private void OnInteraction(InputAction.CallbackContext context) => Debug.LogWarning("Action button pressed!");

    public void ConnectActions()
    {
        if(actionInput != null)
            actionInput.performed += OnInteraction;
    }

    public void DisconnectActions()
    {
        if (actionInput != null)
            actionInput.performed -= OnInteraction;
    }

    public void DisableControls()
    {
        controls.Disable();
    }
    public void EnableControls()
    {
        controls.Enable();
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

    private void Move() {
        Vector3 position = transform.position;
        Vector2 movement = new Vector2(MovementInput.x, MovementInput.y);
        position.x += movement.x * movementSpeed * Time.deltaTime;
        position.y += movement.y * movementSpeed * Time.deltaTime;

        rigidbody2D.MovePosition(position);
    }

    
}
