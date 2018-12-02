using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static int lives = 0;
    public static int tacosCollected = 0;
    public static float time;
    public static string timespend;
    public bool timerplaying;
    public float speed = 1;
    public Texture2D tacoImage;
    public Texture2D timerImage;
    public Texture2D deathsImage;


    // Use this for initialization
    void Start () {

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

}
