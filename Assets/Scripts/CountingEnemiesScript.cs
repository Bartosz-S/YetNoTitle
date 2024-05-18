using UnityEngine;

public class CountEnemies : MonoBehaviour
{
    public void OnMessageReceived()
    {


        // Find all game objects with the tag "Enemies"
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemies");

        // Print the count of enemies to the console
        Debug.Log($"Number of Enemies: {Enemies.Length}");

        // Check if there are no enemies
        if (Enemies.Length == 0)
        {
            Debug.Log("Level completed");
        }
    }
}