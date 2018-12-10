using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacoSpawner : MonoBehaviour {

    public GameObject Taco;


public void TacoLevel1List()
    {
        Instantiate(Taco, new Vector3(12, 0, -1), Quaternion.identity);
        Instantiate(Taco, new Vector3(-9.85f, 7.96f, -1), Quaternion.identity);
        Instantiate(Taco, new Vector3(12.13f, 12.07f, -1), Quaternion.identity);
        Instantiate(Taco, new Vector3(-37.84f, 3.74f, -1), Quaternion.identity);
        Instantiate(Taco, new Vector3(-39.1f, 23.44f, -1), Quaternion.identity);
        Instantiate(Taco, new Vector3(-18.26f, 1.7f, -1), Quaternion.identity);
        Instantiate(Taco, new Vector3(4.5f, 57, -1), Quaternion.identity);
        Instantiate(Taco, new Vector3(-4.33f, 28.19f, -1), Quaternion.identity);
        Instantiate(Taco, new Vector3(-7.96f, 51.28f, -1), Quaternion.identity);
        
    }

    public void TacoBossList()
    {
        Instantiate(Taco, new Vector3(-2.62f, 9.88f, -1), Quaternion.identity);
        Instantiate(Taco, new Vector3(6.48f, 6.76f, -1), Quaternion.identity);
        Instantiate(Taco, new Vector3(96.41f, 11.95f, -1), Quaternion.identity);
        Instantiate(Taco, new Vector3(120.96f, 8.29f, -1), Quaternion.identity);
        Instantiate(Taco, new Vector3(133.1f, 0.29f, -1), Quaternion.identity);
    }

}
