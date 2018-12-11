using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class leaderboard1 : MonoBehaviour {

    public Text[] highscores;
    public Text save;
    int[] tacos;
    string[] time;
    int[] deaths;
    int[] score;
    string[] names;
    public static int submissions;
    
    // Use this for initialization
    void Start () {

        
        score = new int[highscores.Length];
        tacos = new int[highscores.Length];
        time = new string[highscores.Length];
        deaths = new int[highscores.Length];
        names = new string[highscores.Length];
       

        
            for (int x=0; x<tacos.Length; x++)
            {
                tacos[x] = PlayerPrefs.GetInt("tacos" + x);
            }
            for (int x = 0; x < time.Length; x++)
            {
                time[x] = PlayerPrefs.GetString("time" + x);
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
                PlayerPrefs.SetString("time" + x, time[x]);
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

    public void SubmitScore(string name, int taco, int _deaths, string _time, int _score)
    {

        

        for(int x = 0; x<highscores.Length; x++)
        {

            if (!string.IsNullOrEmpty(names[x]))
            {

                submissions++;
                
            }

            
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
        else if (score[4] < _score)
        {
            save.text = "highscore saved";
            score[4] = _score;
            names[4] = name;
            tacos[4] = taco;
            deaths[4] = _deaths;
            time[4] = _time;

        } 
        else
        {
            save.text = "Sorry, not a new highscore. try again";
        }


        int i, j;
        int N = highscores.Length;
        int temp;
        string tempers;

        for (j = N - 1; j > 0; j--)
        {
            for (i = 0; i < j; i++)
            {
                if (score[i] < score[i + 1])
                {

                    temp = score[i+1];
                    score[i + 1] = score[i];
                    score[i] = temp;

                    temp = tacos[i + 1];
                    tacos[i + 1] = tacos[i];
                    tacos[i] = temp;

                    temp = deaths[i + 1];
                    deaths[i + 1] = deaths[i];
                    deaths[i] = temp;

                    tempers = names[i + 1];
                    names[i + 1] = names[i];
                    names[i] = tempers;

                    tempers = time[i + 1];
                    time[i + 1] = time[i];
                    time[i] = tempers;

                }

            }
        }

        savescores();
        drawscores();


    }

  

    void drawscores()
    {

        for (int x = 0; x < highscores.Length; x++)
        {
            if (!string.IsNullOrEmpty(names[x]))
            {
                
                    
                    if(names[x].Length <= 7)
                {
                    switch (names[x].Length)
                    {
                        case 7:
                            highscores[x].text = names[x] + "      " + score[x] + "      " + tacos[x].ToString() + "      " + time[x].ToString() +
                "      " + deaths[x].ToString();
                            break;
                        case 6:
                            highscores[x].text = names[x] + "       " + score[x] + "      " + tacos[x].ToString() + "      " + time[x].ToString() +
                "      " + deaths[x].ToString(); 
                            
                            break; 
                        case 5:
                            highscores[x].text = names[x] + "        " + score[x] + "      " + tacos[x].ToString() + "      " + time[x].ToString() +
                "      " + deaths[x].ToString();
                            break;
                        case 4:
                            highscores[x].text = names[x] + "         " + score[x] + "      " + tacos[x].ToString() + "      " + time[x].ToString() +
                "      " + deaths[x].ToString();
                            break;
                        case 3:
                            highscores[x].text = names[x] + "          " + score[x] + "      " + tacos[x].ToString() + "      " + time[x].ToString() +
                "      " + deaths[x].ToString();
                            break;
                        case 2:
                            highscores[x].text = names[x] + "           " + score[x] + "      " + tacos[x].ToString() + "      " + time[x].ToString() +
                "      " + deaths[x].ToString();
                            break;
                        case 1:
                            highscores[x].text = names[x] + "            " + score[x] + "      " + tacos[x].ToString() + "      " + time[x].ToString() +
                "      " + deaths[x].ToString();
                            break;
                        default:
                           Debug.Log("virker ikke");
                            break;
                    }
                }


                    
            }
            else
                highscores[x].text = " ";
        }
     
    


    }
	// Update is called once per frame
	void Update () {
		
	}
}
