using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI enemyCountText;
    private GameObject[] enemyList;

    private void Start() {
        UpdateEnemiesCount();
        EnemyDeathBehaviour.OnAnyEnemyDeath += EnemyDeathBehaviour_OnAnyEnemyDeath;
    }

    private void EnemyDeathBehaviour_OnAnyEnemyDeath(object sender, System.EventArgs e) {
        UpdateEnemiesCount();
    }

    private void UpdateEnemiesCount() {

        enemyList = GameObject.FindGameObjectsWithTag("Enemies");
        enemyCountText.text = "Enemies left: " + enemyList.Length;
    }
}