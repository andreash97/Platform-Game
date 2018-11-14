using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{


    private bool isPaused = false;


    void Start()
    {

    }


    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
            isPaused = !isPaused;


        if (isPaused)
            Time.timeScale = 0f;

        else
            Time.timeScale = 1.0f;


    }

    void OnGUI()
    {
        if (isPaused)
        {

            if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 - 100, 100, 40), "Continue"))
            {
                isPaused = false;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 - 50, 100, 40), "Restart"))
            {
                SceneManager.LoadScene("Level1");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 + 00, 100, 40), "Quit"))
            {
                Application.Quit();
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 + 50, 100, 40), "Menu"))
            {
                SceneManager.LoadScene("Menu");
            }

        }
    }

}