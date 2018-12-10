using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{

    public float musicSliderValue = 0.0F;
    public float effectSliderValue = 0.0F;
    private bool isPaused = false;
    Player player;
    public AudioMixer music;
    public AudioMixer effect;
    private GUIStyle guiStyle = new GUIStyle();



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
        guiStyle.fontSize = 10;
        guiStyle.normal.textColor = Color.white;
        
       

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
            if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2, 100, 40), "Menu"))
            {
                SceneManager.LoadScene("Menu");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 + 50, 100, 40), "Quit"))
            {
                Application.Quit();
            }

            //Music volume slider
            musicSliderValue = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 60, Screen.height / 2 -120, 100, 30), musicSliderValue, -40.0F, 20.0F);
            string musicText = "Music Volume";
            GUI.Box(new Rect(Screen.width / 2 - 60, Screen.height / 2 - 135, 400, 50), musicText, guiStyle);
            music.SetFloat("Volume", musicSliderValue);

            //Effect volume slider
            effectSliderValue = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 60, Screen.height / 2 - 150, 100, 30), effectSliderValue, -40.0F, 20.0F);
            string effectText = "Effect Volume";
            GUI.Box(new Rect(Screen.width / 2 - 60, Screen.height / 2 - 165, 400, 50), effectText, guiStyle);     
            effect.SetFloat("Volume", effectSliderValue);
         }
    }
}