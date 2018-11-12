using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static int lives = 0;
    public static int tacosCollected = 0;

    // Use this for initialization
    void Start () {
		
	}

    

    void OnGUI()
    {
        string tacoText = "Total tacos: " + tacosCollected;
        GUI.Box(new Rect(Screen.width - 150, 20, 130, 25), tacoText);
        string livesText = "Lives spent: " + lives;
        GUI.Box(new Rect(Screen.width - 150, 50, 130, 25), livesText);
    }

}
