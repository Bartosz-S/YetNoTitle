using System.Collections;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    public Transform player1; // Reference to the player object
    public Transform player2; // Reference to the player object
    private Transform playercurrent; // Reference to the player object


    public GameObject enemyAttackPrefab; // Reference to the EnemyAttack prefab
    public float moveSpeed = 5f; // Speed at which the object moves towards the player
    public float stoppingDistance = 10f; // Distance at which the object stops moving
    public float attackDestroyDelay = 0.5f; // Delay before destroying the EnemyAttack object
    public float attackMoveDistance = 1f;
    public float attackspeed = 2f;

    public bool isMoving = true; // Flag to control movement
    
    public bool isWaitingForAttack = false; // Flag to control waiting for the attack
    
    public bool isRecovering = false;

    private Rigidbody2D rb;


    public float cooldown = 3f;
    private float lastFired = 0;


    public bool left;



    private void Start()
    {
        // Get the Rigidbody component attached to the GameObject
        rb = GetComponent<Rigidbody2D>();
        playercurrent = player1;
    }


    /*
    private void Instance_OnEnemyListCreated(object sender, System.EventArgs e) {
        gameObject.SetActive(false);
    }
    */
    private void FixedUpdate()
    {
        lastFired += Time.deltaTime;
        // Check if the player reference is set
        if (playercurrent != null && isMoving)
        {

            

            // Calculate the direction vector towards the player
            Vector3 directionToPlayer = playercurrent.position - transform.position;

            Vector3 directionToPlayer1 = player1.position - transform.position;
            Vector3 directionToPlayer2 = player2.position - transform.position;
            float distanceToPlayer1 = directionToPlayer1.magnitude;
            float distanceToPlayer2 = directionToPlayer2.magnitude;


            // If the distance is greater than the stopping distance, move towards the player
            if (distanceToPlayer1 > distanceToPlayer2)
            {
                
                playercurrent = player2;
            }


            else
            {
                
                playercurrent = player1;
            }






            if(directionToPlayer.x < 0)
            {
                left = true;
            }
            else
            {
                left = false;
            }


            float directionX = directionToPlayer.x;



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
                
                if (isRecovering == false)
                {
                    lastFired = 0;
                    StartCoroutine(SpawnEnemyAttackAfterDelay()); // Start waiting for the attack
                }              

     

                    if (lastFired > cooldown)                    
                    {
                        isMoving=true;
                        isRecovering=false;
                    }
      

                
                
            }
        }

        if (lastFired > cooldown)                    
        {
        isMoving=true;
        isRecovering=false;
        }


    }





    IEnumerator SpawnEnemyAttackAfterDelay()
    {

        isWaitingForAttack = true; // Set flag to indicate waiting for attack
        Vector3 directionToPlayer = (playercurrent.position - transform.position).normalized;

        yield return new WaitForSeconds(1.4f); // Wait for 2 seconds

        SpawnEnemyAttack(directionToPlayer); // Call SpawnEnemyAttack() after waiting
        isRecovering = true;
        isWaitingForAttack = false; // Reset flag after spawning the attack
        isMoving = true; // Resume movement
        yield return new WaitForSeconds(2f);
        isRecovering = false;
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



            Rigidbody2D rb2D = enemyAttack.GetComponent<Rigidbody2D>();
            rb2D.velocity = directionToPlayer * 5;





            /* Destroy(enemyAttack, attackDestroyDelay); */

        }
        else
        {
            Debug.LogWarning("EnemyAttack prefab is not assigned!");
        }
    }







}
