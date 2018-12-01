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
            if (currentScene.name == "Level design template")
            {
                Player.savedtacos = LevelManager.tacosCollected;
                SceneManager.LoadScene("BossFight", LoadSceneMode.Single);
            }
            if (currentScene.name == "BossFight")
            {
                manager.StopCoroutine("Timer");
                Cursor.visible = true;
                SceneManager.LoadScene("endscene", LoadSceneMode.Single);
            }
            

        }
        
       

    }



}
