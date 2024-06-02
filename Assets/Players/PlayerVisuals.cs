using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerVisuals : MonoBehaviour
{
    [SerializeField] private PlayerReferenceContainer playerReferenceContainer;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    bool lastFlipX;
    private Controls controls;
    private bool isHoldingBlock;

    private void Start() {
        playerReferenceContainer.PlayersHealthSystem.onHealthChange.AddListener(TakeDamageAnimationTrigger);
        controls = new Controls();
        controls.Gameplay.Enable();
        controls.Gameplay.InteractionP1.performed += InteractionP1_performed;
        controls.Gameplay.InteractionP2.performed += InteractionP2_performed;
    }

    private void InteractionP2_performed(UnityEngine.InputSystem.InputAction.CallbackContext context) {
        if (context.performed) {
            animator.SetTrigger("Block");
            isHoldingBlock = true;
            animator.SetBool("IsBlockHolding", true);
        }

        if (context.canceled) {
            isHoldingBlock = false;
            animator.SetBool("IsBlockHolding", false);
        }
    }

    private void InteractionP1_performed(UnityEngine.InputSystem.InputAction.CallbackContext context) {
        if (context.performed) {
            animator.SetTrigger("Attack");
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
}
