using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {


    private float inputDirection;               // Z value of our MoveVector
    private float verticalVelocity;             // Y value of our MoveVector
    private Vector3 moveVector;
    private bool secondJumpAvail = false;

    public Transform player;
    public Transform respawnPoint;

    private float speed = 5.0f;
    private float gravity = 25.0f;

    private CharacterController controller;    
    Animator anim;
	
    
    // Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        
        IsControllerGrounded();
        inputDirection = Input.GetAxis("Horizontal") * speed;
        if (IsControllerGrounded())
        {
            verticalVelocity = 0;

            if (Input.GetKeyDown(KeyCode.W))
            {
                verticalVelocity = 10;
                secondJumpAvail = true;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.W))
            {
                if(secondJumpAvail)
                {
                 verticalVelocity = 10;
                 secondJumpAvail = false;
                }
                
            }
        }

        moveVector = new Vector3(0, verticalVelocity, inputDirection);
        controller.Move(moveVector * Time.deltaTime);

    }

    private bool IsControllerGrounded()
    {
        Vector3 leftRayStart;
        Vector3 RightRayStart;

        leftRayStart = controller.bounds.center;
        RightRayStart = controller.bounds.center;

        leftRayStart.z -= controller.bounds.extents.z;
        RightRayStart.z += controller.bounds.extents.z;

        Debug.DrawRay(leftRayStart, Vector3.down, Color.red);
        Debug.DrawRay(RightRayStart, Vector3.down, Color.green);

        if (Physics.Raycast(leftRayStart, Vector3.down, (controller.height / 2) + 0.1f))
            return true;


        if (Physics.Raycast(RightRayStart, Vector3.down, (controller.height / 2) + 0.1f))
            return true;

        return false;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.gameObject.tag)
        {

            case "Coin":
                LevelManager.tacosCollected++;
                Destroy(hit.gameObject);
                break;
            default:
                break;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Deadly")
        {
            player.transform.position = respawnPoint.transform.position;
            LevelManager.lives++;
            Debug.Log("Dead");
            SceneManager.LoadScene("DeathScreen");

        }
    }

}
