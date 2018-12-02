using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{


    private bool isPaused = false;
    Player player;
    


    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        
    }

   

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if(player.isDead == false)
            {
            Time.timeScale = 1.0f;
            }
                
            
        }

        if (isPaused)
        {
            Cursor.visible = true;
            Time.timeScale = 0f;
            
        }
        
        if(!player.isDead && !isPaused)
        {
            Cursor.visible = false;
        }


    }

    void OnGUI()
    {
        if (isPaused)
        {
            
            if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 - 100, 100, 40), "Continue"))
            {
                isPaused = false;
                if (player.isDead == false)
                {
                    Time.timeScale = 1.0f;
                }
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 - 50, 100, 40), "Restart"))
            {
                player.Restart();
                isPaused = false;
                
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