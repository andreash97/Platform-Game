using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gamecontroller : MonoBehaviour {

    public Text TacoCounter;
    public Text TimeUsed;
    public Text DeathCount;
    public Text Score;

    private int taco;
    private int time;
    private int death;
    private int score;
    public InputField Name;  

    

	// Use this for initialization
	void Start () {


        taco = LevelManager.tacosCollected;
        death = LevelManager.lives;
        time = Mathf.RoundToInt(LevelManager.time);
        score = (1 + taco ) / (1 + time) * 1000;
        Cursor.visible = true;



        TacoCounter.text = "Number of tacos: " + taco;
        TimeUsed.text = "Time Elapsed: " + time;
        DeathCount.text = "Number of deaths: " + death;
        Score.text = "Score: " + score;
    }
	
	// Update is called once per frame
	void Update () {
        
    } 
    public void Submit()
    {
        GetComponent<leaderboard>().SubmitScore(Name.text, taco, death, time, score);
        
    }
}
