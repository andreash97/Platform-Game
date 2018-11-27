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
                Time.timeScale = 1.0f;
                isPaused = false;
                player.isDead = false;
                LevelManager.tacosCollected = 0;
                player.transform.position = player.respawnPoint.transform.position;
                var clones = GameObject.FindGameObjectsWithTag("Taco");
               
                foreach (var clone in clones)
                {
                    Destroy(clone);
                }
                Instantiate(player.Taco, new Vector3(12, 0, -1), Quaternion.identity);
                Instantiate(player.Taco, new Vector3(-9.85f, 7.96f, -1), Quaternion.identity);
                Instantiate(player.Taco, new Vector3(12.13f, 12.07f, -1), Quaternion.identity);
                Instantiate(player.Taco, new Vector3(-37.84f, 3.74f, -1), Quaternion.identity);
                Instantiate(player.Taco, new Vector3(-39.1f, 23.44f, -1), Quaternion.identity);
                Instantiate(player.Taco, new Vector3(-18.26f, 1.7f, -1), Quaternion.identity);
                Instantiate(player.Taco, new Vector3(4.5f, 57, -1), Quaternion.identity);
                Instantiate(player.Taco, new Vector3(-4.33f, 28.19f, -1), Quaternion.identity);
               

            }

            if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 + 00, 100, 40), "Quit"))
            {
                Application.Quit();
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 + 50, 100, 40), "Menu"))
            {
               
                LevelManager.tacosCollected = 0;
                SceneManager.LoadScene("Menu");
                
            }

        }
    }

}