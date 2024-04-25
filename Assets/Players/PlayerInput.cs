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
        transform.Translate(movementSpeed * Time.deltaTime * new Vector2(MovementInput.x, MovementInput.y));
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

    
}
