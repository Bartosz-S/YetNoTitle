using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour {
    public static EnemyList Instance { get; private set; }

    public event EventHandler OnEnemyListUpdate;
    private EnemyDeathBehaviour[] enemyArray;
    private List<EnemyDeathBehaviour> enemyList;

    private void Awake() {
        if (Instance != null) {
            Debug.LogError("There's more that one EnemyList!" + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        UpdateEnemyList();
    }
    private void Start() {
        EnemyDeathBehaviour.OnAnyEnemyDeath += EnemyDeathBehaviour_OnAnyEnemyDeath;
    }

    private void EnemyDeathBehaviour_OnAnyEnemyDeath(object sender, EventArgs e) {
        enemyList.Remove((EnemyDeathBehaviour)sender);
        OnEnemyListUpdate?.Invoke(this, EventArgs.Empty);
    }

    public int GetEnemyListCount() {
        return enemyList.Count;
    }

    private void UpdateEnemyList() {
        enemyList = new List<EnemyDeathBehaviour>();
        foreach(EnemyDeathBehaviour enemy in Resources.FindObjectsOfTypeAll(typeof(EnemyDeathBehaviour)) as EnemyDeathBehaviour[]) {
            enemyList.Add(enemy);
        }
        OnEnemyListUpdate?.Invoke(this, EventArgs.Empty);
    }
}
