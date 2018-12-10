using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Nextlvl : MonoBehaviour {

    LevelManager manager;
    void Start()
    {
        manager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name == "Level 1")
            {
                Player.savedtacos = LevelManager.tacosCollected;
                SceneManager.LoadScene("Level1EndCutScene", LoadSceneMode.Single);
            }
            if (currentScene.name == "Level 1 Easy")
            {
                Player.savedtacos = LevelManager.tacosCollected;
                SceneManager.LoadScene("Level1EndCutScene", LoadSceneMode.Single);
            }
            if (currentScene.name == "BossFight")
            {
                manager.timerplaying = false;
                SceneManager.LoadScene("Scoreboard", LoadSceneMode.Single);
            }
            if (currentScene.name == "BossFight Easy")
            {
                manager.timerplaying = false;
                SceneManager.LoadScene("Scoreboard Easy", LoadSceneMode.Single);
            }


        }
        
       

    }



}
