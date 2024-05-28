using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameWinField : MonoBehaviour
{
    public UnityEvent OnBothPlayersStayInWinZone;
    private List<GameObject> listOfPlayers;

    private void Start() {
        listOfPlayers = new List<GameObject>();
    }


    private void OnTriggerStay2D(Collider2D collision) {
        GameObject player = collision.gameObject;
        if (player.CompareTag("Player")) {
            if(listOfPlayers.Contains(player)) {
                return;
            }
            listOfPlayers.Add(player);
            if(listOfPlayers.Count == 2 && GameObject.FindGameObjectsWithTag("Enemies").Length == 0) {
                OnBothPlayersStayInWinZone.Invoke();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        listOfPlayers.Remove(collision.gameObject);
    }
}
