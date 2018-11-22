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
            Time.timeScale = 0f;


            


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
                isPaused = false;
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
                Time.timeScale = 1.0f;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 + 00, 100, 40), "Quit"))
            {
                Application.Quit();
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 + 50, 100, 40), "Menu"))
            {
                isPaused = false;
                LevelManager.tacosCollected = 0;
                SceneManager.LoadScene("Menu");
                Time.timeScale = 1.0f;
            }

        }
    }

}