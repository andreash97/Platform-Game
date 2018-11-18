using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {

    

    private float inputDirection;               // X value of our MoveVector
    private float verticalVelocity;             // Y value of our MoveVector
    private Vector3 moveVector;
    private bool secondJumpAvail;
    public Transform player;
    public Transform respawnPoint;

    private float speed = 5.0f;
    private float gravity = 25.0f;

    private CharacterController controller;
    private bool facingleft;
    private Animator anim;
    public bool isDead = false;
    public AudioClip JumpSound;
    public AudioSource JumpVolume;
    public AudioSource EatVolume;
    public AudioSource DeathVolume;
    public AudioClip EatSound;
    public AudioClip DeathSound;



    // Use this for initialization
    void Start() {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        facingleft = true;
        JumpVolume.clip = JumpSound;
        EatVolume.clip = EatSound;
        DeathVolume.clip = DeathSound;
    }

    // Update is called once per frame
    void Update() {

        IsControllerGrounded();
        inputDirection = - Input.GetAxisRaw("Horizontal") * speed;
        Flip(inputDirection);

       

        

        if (isDead)
            Time.timeScale = 0f;


        if (IsControllerGrounded())
        {
            verticalVelocity = 0;
            secondJumpAvail = true;
            if (Input.GetKeyDown(KeyCode.W))
            {
                verticalVelocity = 10;
                JumpVolume.Play();
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
                    JumpVolume.Play();
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
        {
             return true;
        }
            


        if (Physics.Raycast(RightRayStart, Vector3.down, (controller.height / 2) + 0.1f))
        {
            return true;
        }
            

        return false;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.gameObject.tag)
        {
            case "Taco":
                LevelManager.tacosCollected++;
                EatVolume.Play();
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
            DeathVolume.Play();
            LevelManager.lives++;

            Debug.Log("Dead");
            isDead = true;


        }
    }

     private void Flip(float horizontal) // will flip the character when moving from left to right and so on.
        {
        if (horizontal > 0 && !facingleft && Time.timeScale == 1.0f || horizontal < 0 && facingleft && Time.timeScale == 1.0f) // using timescale to prevent fliping character while dead or pause
        {
            facingleft = !facingleft;
            Vector3 thescale = transform.localScale;
            thescale.z *= -1;
            transform.localScale = thescale;

        }

        }
    void OnGUI()
    {
        if (isDead)
        {
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                player.transform.position = respawnPoint.transform.position;
                LevelManager.tacosCollected = 0;
                Time.timeScale = 1.0f;
                isDead = false;
               
            }
            string respawnText = "OOPS, YOU DIED! \n Press R to retry or M to get to the main menu.";
            GUI.Box(new Rect(Screen.width - 685, 100, 300, 50), respawnText);
            string tacoText = "Total tacos: " + LevelManager.tacosCollected;
            GUI.Box(new Rect(Screen.width - 600, 200, 130, 25), tacoText);
            string livesText = "Lives spent: " + LevelManager.lives;
            GUI.Box(new Rect(Screen.width - 600, 270, 130, 25), livesText);
        }
        }
}
