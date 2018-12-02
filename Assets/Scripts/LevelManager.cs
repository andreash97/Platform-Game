using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
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

    // Use this for initialization
    void Start () {
        JumpVolume.clip = JumpSound;
        EatVolume.clip = EatSound;
        DeathVolume.clip = DeathSound;
        timerplaying = true;
    }
    public void Update()
    {
        if(timerplaying == true)
        {
            time += Time.deltaTime * speed;
            string hours = Mathf.Floor((time % 216000) / 3600).ToString("00");
            string minutes = Mathf.Floor((time % 3600) / 60).ToString("00");
            string seconds = (time % 60).ToString("00");
            timespend = minutes + ":" + seconds;
            if (time >= 3600) {
                timespend = hours + ":" + minutes + ":" + seconds;
            }
        }
    }

    void OnGUI()
    {
        GUI.backgroundColor = Color.clear;

        string timeText = "" + timespend;
        GUI.Box(new Rect(Screen.width - 75, 20, 60, 25), timeText);
        GUI.Box(new Rect(Screen.width - 122, 10, 75, 37.5f), timerImage);

        //Taco UI
        string tacoText = "" + tacosCollected;
        GUI.Box(new Rect(Screen.width - 60, 50, 30, 25), tacoText);
        GUI.Box(new Rect(Screen.width - 110, 50, 50, 25), tacoImage);

        string deathsText = "" + lives;
        GUI.Box(new Rect(Screen.width - 60, 80, 30, 25), deathsText);
        GUI.Box(new Rect(Screen.width - 116, 80, 62.5f, 31.25f), deathsImage);
    }

    public void DeadOnGUI()
    {
        string respawnText = "OOPS, YOU DIED! \n Press R to retry or M to get to the main menu.";
        GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 50), respawnText);
        string tacoText = "Total tacos: " + LevelManager.tacosCollected;
        GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height / 2 - 100, 130, 25), tacoText);
        string livesText = "Lives spent: " + LevelManager.lives;
        GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height / 2 - 0, 130, 25), livesText);
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
