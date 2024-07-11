using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCounterUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI enemyCountText;

    private void Start() {
        EnemyList.Instance.OnEnemyListUpdate += EnemyList_OnEnemyListUpdate;
        EnemyList.Instance.OnEnemyListCreated += EnemyList_OnEnemyListCreated;
        Debug.Log("EnemyCounterStart");
    }

    private void EnemyList_OnEnemyListCreated(object sender, System.EventArgs e) {
        enemyCountText.text = "Enemies left: " + EnemyList.Instance.GetEnemyListCount();
        Debug.Log("EnemyCounterTextStart");
    }

    private void EnemyList_OnEnemyListUpdate(object sender, System.EventArgs e) {
        Debug.Log("SignalFromEnemyList");
        if (enemyCountText != null) {
        int enemyCountMinusTwo = EnemyList.Instance.GetEnemyListCount();
            enemyCountText.text = "Enemies left: " + enemyCountMinusTwo;
            Debug.Log("EnemyCounterSignal");
        }
    }
}