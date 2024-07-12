using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour {
    public static EnemyList Instance { get; private set; }

    public event EventHandler OnEnemyListUpdate;
    public event EventHandler OnNoMoreEnemies;
    public event EventHandler OnEnemyListCreated;
    private EnemyDeathBehaviour[] enemyArray;
    private List<EnemyDeathBehaviour> enemyList;

    private void Awake() {
        if (Instance != null) {
            Debug.LogError("There's more that one EnemyList!" + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Start() {

        enemyList = new List<EnemyDeathBehaviour>();
        EnemyDeathBehaviour[] enemyArray = Resources.FindObjectsOfTypeAll<EnemyDeathBehaviour>();

        foreach(EnemyDeathBehaviour e in enemyArray) {
            enemyList.Add(e);
        }

        Debug.Log(enemyList.Count);
        OnEnemyListCreated?.Invoke(this, EventArgs.Empty);
        EnemyDeathBehaviour.OnAnyEnemyDeath += EnemyDeathBehaviour_OnAnyEnemyDeath;
        Debug.Log("EnemyList start");
    }

    private void EnemyDeathBehaviour_OnAnyEnemyDeath(object sender, EventArgs e) {
        Debug.Log("EnemyList death");
        enemyList.Remove((EnemyDeathBehaviour)sender);
        if (enemyList.Count == 0) {
            OnNoMoreEnemies?.Invoke(this, EventArgs.Empty);
        }
        OnEnemyListUpdate?.Invoke(this, EventArgs.Empty);
        Debug.Log(enemyList.Count);
    }

    public int GetEnemyListCount() {
        return enemyList.Count;
    }
}
