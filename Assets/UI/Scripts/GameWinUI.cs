using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameWinUI : MonoBehaviour
{
    [SerializeField] private Button backToMainMenuBtn;
    [SerializeField] private Button restartBtn;
    [SerializeField] private GameWinField gameWinField;


    private void Start() {
        gameObject.SetActive(false);
        backToMainMenuBtn.onClick.AddListener(BackToMainMenuScene);
        restartBtn.onClick.AddListener(RestartScene);
        gameWinField.OnBothPlayersStayInWinZone.AddListener(OnWin);
    }

    private void BackToMainMenuScene() {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    private void RestartScene() {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;

    }
    private void OnWin() {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
