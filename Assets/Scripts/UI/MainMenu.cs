using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button quitButton;

    private void Start() {
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);

    }
    private void PlayGame() {
        SceneManager.LoadScene(1);
    }
    private void QuitGame() {
        Application.Quit();
    }
}
