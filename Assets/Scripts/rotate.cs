using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class rotate : MonoBehaviour
{

    float Angle;

  
    // Update is called once per frame
    void Update()
    {
        Angle = Quaternion.Angle(Quaternion.Euler(new Vector2(0, 0)), transform.rotation);

        if (Input.GetKey(KeyCode.A)&&Angle==180)
        {
            transform.RotateAround(transform.position, Vector2.up, 180);
        }
        else if (Input.GetKey(KeyCode.D)&&Angle==0)
        {
            transform.RotateAround(transform.position, Vector2.up, 180);
        }

        Debug.Log(Angle);
    }

}