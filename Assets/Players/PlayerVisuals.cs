using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerVisuals : MonoBehaviour
{
    [SerializeField] private PlayerReferenceContainer playerReferenceContainer;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start() {
        playerReferenceContainer.PlayersHealthSystem.onHealthChange.AddListener(TakeDamageAnimationTrigger);
    }
    private void Update() {
        if (playerReferenceContainer.PlayersInput.MovementInput != new Vector2(0, 0)) {

            animator.SetBool("IsWalking", true);
        } else {
            animator.SetBool("IsWalking", false);
        }
        // flips sprite to the moving direction
        spriteRenderer.flipX = playerReferenceContainer.PlayersInput.MovementInput.x < 0f;
    }

    private void TakeDamageAnimationTrigger() {
        animator.SetTrigger("TakingDamage");
        Debug.Log("Event OnHealthChange");
    }
}
