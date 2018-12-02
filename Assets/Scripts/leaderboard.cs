using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leaderboard : MonoBehaviour {

    public Text[] highscores;
    public Text save;
    int[] tacos;
    int[] time;
    int[] deaths;
    int[] score;
    string[] names;
    public static int submissions;
	// Use this for initialization
	void Start () {

        
        score = new int[highscores.Length];
        tacos = new int[highscores.Length];
        time = new int[highscores.Length];
        deaths = new int[highscores.Length];
        names = new string[highscores.Length];

        for (int x=0; x<tacos.Length; x++)
        {
            tacos[x] = PlayerPrefs.GetInt("tacos" + x);
        }
        for (int x = 0; x < time.Length; x++)
        {
            time[x] = PlayerPrefs.GetInt("time" + x);
        }
        for (int x = 0; x < deaths.Length; x++)
        {
            deaths[x] = PlayerPrefs.GetInt("deaths" + x);
        }
        for (int x = 0; x < names.Length; x++)
        {
            names[x] = PlayerPrefs.GetString("names" + x);
        }
        for (int x = 0; x < score.Length; x++)
        { 
            score[x] = PlayerPrefs.GetInt("score" + x);
        }

        drawscores();
    }
	
    void savescores() {

        for (int x = 0; x < tacos.Length; x++)
        {
            PlayerPrefs.SetInt("tacos" + x, tacos [x]);
        }
        for (int x = 0; x < time.Length; x++)
        {
            PlayerPrefs.SetInt("time" + x, time[x]);
        }
        for (int x = 0; x < tacos.Length; x++)
        {
            PlayerPrefs.SetInt("deaths" + x, deaths[x]);
        }
        for (int x = 0; x < names.Length; x++)
        {
            PlayerPrefs.SetString("names" + x, names[x]);
        }
        for (int x = 0; x < score.Length; x++)
        {
            PlayerPrefs.SetInt("score" + x, score[x]);
        }
    }

    public void SubmitScore(string name, int taco, int _deaths, int _time, int _score)
    {
        
        for(int x = 0; x<highscores.Length; x++)
        {

            if (!string.IsNullOrEmpty(names[x]))
            {

                submissions++;
                
            }

            Debug.Log(submissions);
            Debug.Log(names[x]);
        }

        if (submissions < highscores.Length)
        {
            save.text = "highscore saved";
            names[submissions] = name;
            tacos[submissions] = taco;
            deaths[submissions] = _deaths;
            score[submissions] = _score;
            time[submissions] = _time; 
        }
        else if (score[9] < _score)
        {
            save.text = "highscore saved";
            score[9] = _score;
            names[9] = name;
            tacos[9] = taco;
            deaths[9] = _deaths;
            time[9] = _time;

        } 
        else
        {
            save.text = "Sorry, not a new highscore. try again";
        }

        for (int x = 0; x < highscores.Length; x++)
        {

            int temp = 0;
            string temp2;

            for (int sort = 0; sort < score.Length - 1; sort++)
            {
                if (score[sort] > score[sort + 1])
                {
                    temp = score[sort + 1];
                    score[sort + 1] = score[sort];
                    score[sort] = temp;

                    temp = tacos[sort + 1];
                    tacos[sort + 1] = tacos[sort];
                    score[sort] = temp;

                    temp = deaths[sort + 1];
                    deaths[sort + 1] = deaths[sort];
                    score[sort] = temp;

                    temp = time[sort + 1];
                    time[sort + 1] = time[sort];
                    time[sort] = temp;

                    temp2 = names[sort + 1];
                    names[sort + 1] = names[sort];
                    names[sort] = temp2;


                }





            }




            savescores();
            drawscores();
            
        }
    }

    void drawscores()
    {

        for (int x = 0; x < highscores.Length; x++)
        {
            if (!string.IsNullOrEmpty(names[x]))
            {
                highscores[x].text = names[x] + " score: " + score[x] + " tacos: " + tacos[x].ToString() + " time(s): " + time[x].ToString() +
                " deaths: " + deaths[x].ToString();
            }
            else
                highscores[x].text = " ";
        }
     
    


    }
	// Update is called once per frame
	void Update () {
		
	}
}
