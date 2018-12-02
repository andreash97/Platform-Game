using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    void Start()
    {
        Cursor.visible = true;
    }
    public void PlayGame ()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1.0f;
        LevelManager.tacosCollected = 0;
        LevelManager.time = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
