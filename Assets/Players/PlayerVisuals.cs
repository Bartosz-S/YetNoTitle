using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Update() {
        if (playerInput.MovementInput != new Vector2(0, 0)) {

            animator.SetBool("IsWalking", true);
        } else {
            animator.SetBool("IsWalking", false);
        }
        // flips sprite to the moving direction
        spriteRenderer.flipX = playerInput.MovementInput.x < 0f;
    }
}
