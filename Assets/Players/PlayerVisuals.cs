using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerVisuals : MonoBehaviour
{
    [SerializeField] private PlayerReferenceContainer playerReferenceContainer;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Controls controls;

    private void Start() {
        playerReferenceContainer.PlayersHealthSystem.onHealthChange.AddListener(TakeDamageAnimationTrigger);
        controls = new Controls();
        controls.Gameplay.Enable();
        controls.Gameplay.InteractionP1.performed += InteractionP1_performed;
        controls.Gameplay.InteractionP2.started += InteractionP2_started;
        controls.Gameplay.InteractionP2.canceled += InteractionP2_canceled;
    }

    private void InteractionP1_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        if (playerReferenceContainer.PlayersInput.GetPlayerNumber() == PlayerInput.PlayerNumber.Player1) {
            //animator.SetTrigger("Attack");
        }
    }
    private void InteractionP2_started(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        if (playerReferenceContainer.PlayersInput.GetPlayerNumber() == PlayerInput.PlayerNumber.Player2) {
            animator.SetTrigger("Block");
            animator.SetBool("IsBlocking", true);
        }
    }
    private void InteractionP2_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        if (playerReferenceContainer.PlayersInput.GetPlayerNumber() == PlayerInput.PlayerNumber.Player2) {
            animator.SetBool("IsBlocking", false);
        }
    }

    private void Update() {      
        if (playerReferenceContainer.PlayersInput.MovementInput != new Vector2(0, 0)) {

            animator.SetBool("IsWalking", true);
            if (playerReferenceContainer.PlayersInput.MovementInput.x < 0f) {
                spriteRenderer.flipX = true;
            } 
            if (playerReferenceContainer.PlayersInput.MovementInput.x > 0f){
                spriteRenderer.flipX = false;
            }
        } else {
            animator.SetBool("IsWalking", false);
        }
    }

    private void TakeDamageAnimationTrigger() {
        animator.SetTrigger("TakingDamage");
    }
    public Animator GetAnimator() {
        return animator;
    }
}
