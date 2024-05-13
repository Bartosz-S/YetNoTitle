using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerVisuals : MonoBehaviour
{
    [SerializeField] private PlayerReferenceContainer playerReferenceContainer;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    bool lastFlipX;

    private void Start() {
        playerReferenceContainer.PlayersHealthSystem.onHealthChange.AddListener(TakeDamageAnimationTrigger);
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
