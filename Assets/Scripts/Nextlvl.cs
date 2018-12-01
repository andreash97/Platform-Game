using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Nextlvl : MonoBehaviour {


    Player player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

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
                player.finish();
                Cursor.visible = true;
                SceneManager.LoadScene("endscene", LoadSceneMode.Single);
            }
            

        }
        
       

    }



}
