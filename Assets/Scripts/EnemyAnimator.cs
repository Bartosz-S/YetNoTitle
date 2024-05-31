using UnityEngine;

public class PlayAnimationOnMove : MonoBehaviour
{


    private MoveTowardsPlayer parentScript;

    // Reference to the Animator component
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    // Public boolean to control animation, accessible from other scripts
    public bool isMoving = false;
    public bool isWaitingForAttack = false;

    public bool left = false;

    private void Start()
{

    parentScript = transform.parent.GetComponent<MoveTowardsPlayer>(); //If assigned in inspector delete this

        // Get the Animator component attached to the GameObject
    animator = GetComponent<Animator>();
    spriteRenderer = GetComponent<SpriteRenderer>();
}


    void Update()
    {

        if(parentScript.left == true)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        // Check if isMoving is true and play the animation
        if (parentScript.isMoving)
        {
            animator.Play("EnemyWalk");
        }
        else
        {

            if (parentScript.isWaitingForAttack)
            {
            // Optional: You can stop the animation or play another animation if needed
            animator.Play("EnemyAttack");
            }
            else
            {
            animator.Play("EnemyIdle");
            }

        }
    }


}