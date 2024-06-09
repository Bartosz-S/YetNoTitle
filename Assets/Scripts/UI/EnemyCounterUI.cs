using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCounterUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI enemyCountText;

    private void Start() {
        EnemyList.Instance.OnEnemyListUpdate += EnemyList_OnEnemyListUpdate;
        EnemyList.Instance.OnEnemyListCreated += EnemyList_OnEnemyListCreated;
    }

    private void EnemyList_OnEnemyListCreated(object sender, System.EventArgs e) {
        enemyCountText.text = "Enemies left: " + EnemyList.Instance.GetEnemyListCount();
    }

    private void EnemyList_OnEnemyListUpdate(object sender, System.EventArgs e) {
        if (enemyCountText != null) {
            enemyCountText.text = "Enemies left: " + EnemyList.Instance.GetEnemyListCount();
        }
    }
}