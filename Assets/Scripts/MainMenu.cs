using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public static string difficulty;
    void Start()
    {
        Cursor.visible = true;
    }
    public void PlayEasyGame ()
    {
        SceneManager.LoadScene("StartCutScene");
        difficulty = "Easy";
        Time.timeScale = 1.0f;
        LevelManager.tacosCollected = 0;
        LevelManager.time = 0;
    }

    public void PlayNormalGame()
    {
        difficulty = "Normal";
        SceneManager.LoadScene("StartCutScene");
        Time.timeScale = 1.0f;
        LevelManager.tacosCollected = 0;
        LevelManager.time = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
