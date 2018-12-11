using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private float delayBeforLoading = 10f;
    private float timeElapsed;
    public Animator animator;

    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delayBeforLoading || (Input.GetKeyDown(KeyCode.Escape)))
        {
            animator.SetTrigger("FadeOut");


        }
    }
    public void OnFadeComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "StartCutScene")
        {
            SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
        }
        if (currentScene.name == "StartCutScene" && MainMenu.difficulty == "Easy")
        {
            SceneManager.LoadScene("Level 1 Easy", LoadSceneMode.Single);
        }
        if (currentScene.name == "Level1EndCutScene")
        {
            SceneManager.LoadScene("Bossfight", LoadSceneMode.Single);
        }
        if (currentScene.name == "Level1EndCutScene" && MainMenu.difficulty == "Easy")
        {
            SceneManager.LoadScene("Bossfight Easy", LoadSceneMode.Single);
        }

    }
}