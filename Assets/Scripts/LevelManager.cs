using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public AudioClip JumpSound;
    public AudioSource JumpVolume;
    public AudioSource EatVolume;
    public AudioSource DeathVolume;
    public AudioClip EatSound;
    public AudioClip DeathSound;
    public static int lives = 0;
    public static int tacosCollected = 0;
    public static float time;
    public static string timespend;
    public bool timerplaying;
    public float speed = 1;
    public Texture2D tacoImage;
    public Texture2D timerImage;
    public Texture2D deathsImage;
    public Transform player;
    public Transform respawnPoint;
    private GUIStyle guiStyle = new GUIStyle();

    // Use this for initialization
    void Start()
    {
        JumpVolume.clip = JumpSound;
        EatVolume.clip = EatSound;
        DeathVolume.clip = DeathSound;
        timerplaying = true;
    }
    public void Update()
    {
        if (timerplaying == true)
        {
            time += Time.deltaTime * speed;
            string hours = Mathf.Floor((time % 216000) / 3600).ToString("00");
            string minutes = Mathf.Floor((time % 3600) / 60).ToString("00");
            string seconds = (time % 60).ToString("00");
            timespend = minutes + ":" + seconds;
            if (time >= 3600)
            {
                timespend = hours + ":" + minutes + ":" + seconds;
            }
        }
    }

    public void DeadOnGUI()
    {
        guiStyle.fontSize = 40;
        guiStyle.normal.textColor = Color.white;
        GUI.backgroundColor = Color.clear;
        guiStyle.font = Resources.Load<Font>("Another Brick");

        string respawnText = "                       YOU WERE CAUGHT! \n PRESS R TO RETRY OR M TO GO TO THE MAIN MENU";
        GUI.Box(new Rect(Screen.width / 2 - 390, Screen.height / 2 - 160, 400, 50), respawnText, guiStyle);

        string tacoText = "" + tacosCollected;
        GUI.Box(new Rect(Screen.width / 2 + 60, Screen.height / 2 + 100, 60, 50), tacoText, guiStyle);
        GUI.Box(new Rect(Screen.width / 2 - 110, Screen.height / 2 + 75, 150, 75), tacoImage);

        string deathsText = "" + lives;
        GUI.Box(new Rect(Screen.width / 2 + 60, Screen.height / 2 + 190, 60, 50), deathsText, guiStyle);
        GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 180, 125, 62.5f), deathsImage);
    }

    void OnGUI()
    {
        GUI.backgroundColor = Color.clear;
        guiStyle.fontSize = 20;
        guiStyle.normal.textColor = Color.white;
        GUI.backgroundColor = Color.clear;
        guiStyle.font = Resources.Load<Font>("Another Brick");

        string timeText = "" + timespend;
        GUI.Box(new Rect(Screen.width - 75, 25, 60, 25), timeText, guiStyle);
        GUI.Box(new Rect(Screen.width - 155, 10, 93.75f, 46.875f), timerImage);

        //Taco UI
        string tacoText = "" + tacosCollected;
        GUI.Box(new Rect(Screen.width - 60, 68, 30, 25), tacoText, guiStyle);
        GUI.Box(new Rect(Screen.width - 138, 63, 62.5f, 31.25f), tacoImage);

        string deathsText = "" + lives;
        GUI.Box(new Rect(Screen.width - 60, 110, 30, 25), deathsText, guiStyle);
        GUI.Box(new Rect(Screen.width - 145, 100, 78.125f, 39.0625f), deathsImage);

    }


    public void Spawn()
    {
        player.transform.position = respawnPoint.transform.position;
    }

    public void Jump()
    {
        JumpVolume.Play();
    }

    public void Taco()
    {
        LevelManager.tacosCollected++;
        EatVolume.Play();
    }

    public void Dead()
    {
        DeathVolume.Play();
        LevelManager.lives++;
    }
}
