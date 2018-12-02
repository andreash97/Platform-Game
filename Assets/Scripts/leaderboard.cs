using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leaderboard : MonoBehaviour {

    public Text[] highscores;

    int[] tacos;
    float [] time;
    int[] deaths;
    string[] names;
	// Use this for initialization
	void Start () {

        
        tacos = new int[highscores.Length];
        time = new float[highscores.Length];
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

        drawscores();
    }
	
    void savescores() {

        for (int x = 0; x < tacos.Length; x++)
        {
            PlayerPrefs.SetInt("tacos" + x, tacos [x]);
        }
        for (int x = 0; x < time.Length; x++)
        {
            PlayerPrefs.SetFloat("time" + x, time[x]);
        }
        for (int x = 0; x < tacos.Length; x++)
        {
            PlayerPrefs.SetInt("deaths" + x, deaths[x]);
        }
        for (int x = 0; x < names.Length; x++)
        {
            PlayerPrefs.SetString("names" + x, names[x]);
        }
    } 

    public void SubmitScore(string name, int taco, int _deaths, float _time)
    {

        for (int x = 0; x < highscores.Length; x++) {

            if (names[x] == null)
            {
                tacos[x] = taco;
                time[x] = _time;
                deaths[x] = _deaths;
                names[x] = name;
                break;
            } 

            if(x == 2)
            {
                tacos[2] = tacos[1];
                time[2] = time[1];
                deaths[2] = deaths[1];
                names[2] = names[1]; 

                tacos[1] = tacos[0];
                time[1] = time[0];
                deaths[1] = deaths[0];
                names[1] = names[0];

                tacos[0] = taco;
                time[0] = _time;
                deaths[0] = _deaths;
                names[0] = name; 


                break;

            }


        }




        savescores();
        drawscores();
    }

    void drawscores()
    {

        for (int x = 0; x < highscores.Length; x++)
        {
            highscores[x].text = names[x] + " tacos: " + tacos[x].ToString() + " Time Spend: " + time[x].ToString() +
            " deaths: " + deaths[x].ToString();
          
        }
     
    


    }
	// Update is called once per frame
	void Update () {
		
	}
}
