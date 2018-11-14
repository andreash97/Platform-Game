using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {


    private float inputDirection;               // X value of our MoveVector
    private float verticalVelocity;             // Y value of our MoveVector
    private Vector3 moveVector;
    private bool secondJumpAvail = false;

    public Transform player;
    public Transform respawnPoint;

    private float speed = 5.0f;
    private float gravity = 25.0f;

    private CharacterController controller;
    private bool facingleft;

    // Use this for initialization
    void Start() {
        controller = GetComponent<CharacterController>();
        facingleft = true;
    }

    // Update is called once per frame
    void Update() {

        IsControllerGrounded();
        float inputDirection = -Input.GetAxis("Horizontal") * speed;
        Flip(inputDirection);
        if (IsControllerGrounded())
        {
            verticalVelocity = 0;
            secondJumpAvail = true;
            if (Input.GetKeyDown(KeyCode.W))
            {
                verticalVelocity = 10;

            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (secondJumpAvail)
                {
                    verticalVelocity = 10;
                    secondJumpAvail = false;
                }

            }
        }

        moveVector = new Vector3(inputDirection, verticalVelocity, 0);
        controller.Move(moveVector * Time.deltaTime);

    }

    private bool IsControllerGrounded()
    {
        Vector3 leftRayStart;
        Vector3 RightRayStart;

        leftRayStart = controller.bounds.center;
        RightRayStart = controller.bounds.center;

        leftRayStart.x -= controller.bounds.extents.x;
        RightRayStart.x += controller.bounds.extents.x;

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

     private void Flip(float horizontal) // will flip the character when moving from left to right and so on.
        {
        if(horizontal > 0 && !facingleft || horizontal < 0 && facingleft)
        {
            facingleft = !facingleft;
            Vector3 thescale = transform.localScale;
            thescale.z *= -1;
            transform.localScale = thescale;

        }

        }

}
