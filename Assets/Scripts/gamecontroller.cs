using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gamecontroller : MonoBehaviour
{

    public Text TacoCounter;
    public Text TimeUsed;
    public Text DeathCount;
    public Text Score;

    private int taco;
    private string time;
    private int death;
    private int score;
    private float scoremath;
    private float timemath;
    public InputField Name;
    public GameObject myButton;
    public GameObject myInput;
    public GameObject myText;


    // Use this for initialization
    void Start()
    {

        Cursor.visible = true;
        taco = LevelManager.tacosCollected;
        death = LevelManager.lives;
        time = LevelManager.timespend;
        timemath = Mathf.RoundToInt(LevelManager.time);
        scoremath = ((taco * 100) / (timemath / 5));
        score = Mathf.RoundToInt(scoremath);

        if (taco == 0 || timemath == 0)
        {
            score = 0;
        }


        TacoCounter.text = "Number of tacos: " + taco;
        TimeUsed.text = "Time Elapsed: " + time;
        DeathCount.text = "Number of deaths: " + death;
        Score.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Submit()
    {
        GetComponent<leaderboard>().SubmitScore(Name.text, taco, death, time, score);
        myButton.SetActive(false);
        myInput.SetActive(false);
        myText.SetActive(false);
    }
}
