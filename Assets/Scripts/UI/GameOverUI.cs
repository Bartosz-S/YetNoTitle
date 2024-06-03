using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button backToMainMenuBtn;
    [SerializeField] private Button restartBtn;
    [SerializeField] private PlayerReferenceContainer player1;
    [SerializeField] private PlayerReferenceContainer player2;




    private void Start() {
        gameObject.SetActive(false);
        backToMainMenuBtn.onClick.AddListener(BackToMainMenuScene);
        restartBtn.onClick.AddListener(RestartScene);
        player1.PlayersHealthSystem.onHealthChange.AddListener(OnDeath);
        player2.PlayersHealthSystem.onHealthChange.AddListener(OnDeath);
    }

    private void BackToMainMenuScene() {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    private void RestartScene() {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;

    }
    private void OnDeath() {
        if (!player1.PlayersHealthSystem.IsAlive || !player2.PlayersHealthSystem.IsAlive) {
            gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
