using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level1");
            LevelManager.tacosCollected = 0;
        }
        if( Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Menu");
            LevelManager.tacosCollected = 0;
        }

    }

    void OnGUI()
    {
       string respawnText = "OOPS, YOU DIED! \n Press R to retry or M to get to the main menu.";
        GUI.Box(new Rect(Screen.width - 685, 100, 300, 50), respawnText);        
        string tacoText = "Total tacos: " + LevelManager.tacosCollected;
        GUI.Box(new Rect(Screen.width - 600, 200, 130, 25), tacoText);
        string livesText = "Lives spent: " + LevelManager.lives;
        GUI.Box(new Rect(Screen.width - 600, 270, 130, 25), livesText);
    }
}
