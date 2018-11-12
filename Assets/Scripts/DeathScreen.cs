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
        }

    }

    void OnGUI()
    {
        string tacoText = "Total tacos: " + LevelManager.tacosCollected;
        GUI.Box(new Rect(Screen.width - 600, 200, 130, 25), tacoText);
        string livesText = "Lives spent: " + LevelManager.lives;
        GUI.Box(new Rect(Screen.width - 600, 270, 130, 25), livesText);
    }
}
