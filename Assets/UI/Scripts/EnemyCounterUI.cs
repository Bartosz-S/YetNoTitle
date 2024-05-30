using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCounterUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI enemyCountText;

    private void Start() {
        EnemyList.Instance.OnEnemyListUpdate += Instance_OnEnemyListUpdate;
        enemyCountText.text = "Enemies left: " + EnemyList.Instance.GetEnemyListCount();
    }

    private void Instance_OnEnemyListUpdate(object sender, System.EventArgs e) {
        if (enemyCountText != null) {
            enemyCountText.text = "Enemies left: " + EnemyList.Instance.GetEnemyListCount();
        }
    }
}