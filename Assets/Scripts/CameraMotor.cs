using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

    private Vector3 offset = new Vector3(-11f, 1, 0);

    public Transform lookAt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = lookAt.transform.position + offset;
	}
}
