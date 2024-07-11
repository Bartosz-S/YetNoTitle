using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameWinField : MonoBehaviour
{
    public UnityEvent OnBothPlayersStayInWinZone;
    private List<GameObject> listOfPlayers;
    [SerializeField] private GameObject closeGatesSprite;
    [SerializeField] private GameObject openGatesSprite;
    private bool isGateOpen;

    private void Start() {
        listOfPlayers = new List<GameObject>();
        closeGatesSprite.SetActive(true);
        openGatesSprite.SetActive(false);
        EnemyList.Instance.OnNoMoreEnemies += EnemyList_OnNoMoreEnemies;
        
    }

    private void EnemyList_OnNoMoreEnemies(object sender, EventArgs e) {
        isGateOpen = true;
        closeGatesSprite.SetActive(false);
        openGatesSprite.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject player = collision.gameObject;
        if (player.CompareTag("Player")) {
            if(listOfPlayers.Contains(player)) {
                return;
            }
            listOfPlayers.Add(player);
            if(listOfPlayers.Count == 2 && isGateOpen) {
                OnBothPlayersStayInWinZone.Invoke();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        listOfPlayers.Remove(collision.gameObject);
    }
}
