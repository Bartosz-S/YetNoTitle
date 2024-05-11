using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button backToMainMenu;



    private void Start() {
        backToMainMenu.onClick.AddListener(BackToMainMenuScene);
    }

    private void BackToMainMenuScene() {
        SceneManager.LoadScene(0);
    }
}
