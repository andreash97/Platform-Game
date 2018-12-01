using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gamecontroller : MonoBehaviour {

    public Text TacoCounter;
    public Text TimeUsed;
    public Text DeathCount;
    public InputField Name;  

    

	// Use this for initialization
	void Start () {
        TacoCounter.text = "Number of tacos: " + LevelManager.tacosCollected; 
        TimeUsed.text = "Time Elapsed: " + LevelManager.time;
        DeathCount.text = "Number of deaths: " + LevelManager.lives; 
    }
	
	// Update is called once per frame
	void Update () {
        
    } 
    public void Submit()
    {
        GetComponent<leaderboard>().SubmitScore(Name.text, LevelManager.tacosCollected, LevelManager.lives, LevelManager.time);

    }
}
