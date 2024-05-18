using System.Collections;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    public Transform player1; // Reference to the player object
    public GameObject enemyAttackPrefab; // Reference to the EnemyAttack prefab
    public float moveSpeed = 5f; // Speed at which the object moves towards the player
    public float stoppingDistance = 5f; // Distance at which the object stops moving
    public float attackDestroyDelay = 0.5f; // Delay before destroying the EnemyAttack object
    public float attackMoveDistance = 1f;

    public Sprite[] sprites; // Array of sprites to cycle through
    private int currentSpriteIndex = 0; // Index of the current sprite

    private bool isMoving = true; // Flag to control movement
    /*
    private bool isWaitingForAttack = false; // Flag to control waiting for the attack
    */


    private Rigidbody2D rb;


    private void Start()
    {
        // Get the Rigidbody component attached to the GameObject
        rb = GetComponent<Rigidbody2D>();
    }










    private void FixedUpdate()
    {
        // Check if the player reference is set
        if (player1 != null && isMoving)
        {
            // Calculate the direction vector towards the player
            Vector3 directionToPlayer = player1.position - transform.position;

            // Calculate the distance to the player
            float distanceToPlayer = directionToPlayer.magnitude;

            // If the distance is greater than the stopping distance, move towards the player
            if (distanceToPlayer > stoppingDistance)
            {
                // Normalize the direction vector and move the object towards the player
                rb.AddForce(directionToPlayer.normalized * moveSpeed, ForceMode2D.Force);
            }
            else
            {
                isMoving = false; // Stop movement
                
                StartCoroutine(SpawnEnemyAttackAfterDelay()); // Start waiting for the attack
                
            }
        }
    }





    IEnumerator SpawnEnemyAttackAfterDelay()
    {

        /* isWaitingForAttack = true; // Set flag to indicate waiting for attack */
        Vector3 directionToPlayer = (player1.position - transform.position).normalized;
        ChangeSprite();
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        ChangeSprite();
        SpawnEnemyAttack(directionToPlayer); // Call SpawnEnemyAttack() after waiting
        /* isWaitingForAttack = false; // Reset flag after spawning the attack */
        isMoving = true; // Resume movement
    }

    // Function to spawn the EnemyAttack object on top of this object
    void SpawnEnemyAttack(Vector3 directionToPlayer)
    {
        if (enemyAttackPrefab != null)
        {
            
            
            // Spawn the EnemyAttack object on top of this object
            GameObject enemyAttack = Instantiate(enemyAttackPrefab, transform.position, Quaternion.identity);


            enemyAttack.transform.Translate(directionToPlayer * attackMoveDistance);


            // Calculate the angle to rotate towards the player
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

            // Apply the rotation to the enemy attack object (only on the Z axis)
            enemyAttack.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));





            Destroy(enemyAttack, attackDestroyDelay);

        }
        else
        {
            Debug.LogWarning("EnemyAttack prefab is not assigned!");
        }
    }


    void ChangeSprite()
    {
        // Check if there's a sprite renderer attached to the GameObject
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // Change the sprite to the next sprite in the array
            spriteRenderer.sprite = sprites[currentSpriteIndex];

            // Increment the counter and loop back to the beginning if necessary
            currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length;
        }
        else
        {
            Debug.LogError("SpriteRenderer component not found on this GameObject!");
        }
    }




}
