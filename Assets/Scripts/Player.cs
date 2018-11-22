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
    public GameObject Taco;

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
    private float pressJump;
    private float groundedtimer;
    private bool landingTrigger;


    // Use this for initialization
    void Start() {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        facingleft = true;
        JumpVolume.clip = JumpSound;
        EatVolume.clip = EatSound;
        DeathVolume.clip = DeathSound;
        Instantiate(Taco, new Vector3(12, 0, -1), Quaternion.identity);
        Instantiate(Taco, new Vector3(-9.85f, 7.96f, -1), Quaternion.identity);
        Instantiate(Taco, new Vector3(12.13f, 12.07f, -1), Quaternion.identity);
        Instantiate(Taco, new Vector3(-37.84f, 3.74f, -1), Quaternion.identity);
        Instantiate(Taco, new Vector3(-39.1f, 23.44f, -1), Quaternion.identity);
        Instantiate(Taco, new Vector3(-18.26f, 1.7f, -1), Quaternion.identity);

    }

    // Update is called once per frame
    void Update() {
       

        IsControllerGrounded();
        inputDirection = -Input.GetAxisRaw("Horizontal") * speed;
        Flip(inputDirection);
        HandleLayers();


        if (landingTrigger == true) { 
        Checklanding();
        }



        if (isDead)
        {
            Time.timeScale = 0f;
        }


        groundedtimer -= Time.deltaTime; // makes it so that edge jumping is smoother by making you grounded alittle longer than in reality.
        pressJump -= Time.deltaTime; // makes it so that if you press jump button right before landing you will infact jump.


        if (Input.GetKeyDown(KeyCode.W))
        {
            pressJump = 0.15f;
            
        }

        if (groundedtimer > 0)
        {
            landingTrigger = false;
            anim.SetBool("landing", false);

        }


        if (groundedtimer >0) 
        {
           
            verticalVelocity = 0;
            secondJumpAvail = true;
            if (pressJump > 0 && (groundedtimer >0))
            {
                landingTrigger = true;
                groundedtimer = 0;
                anim.SetFloat("groundedtimer", 0);
                pressJump = 0;
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
        anim.SetFloat("speed", Mathf.Abs(inputDirection));

    }

    private void Checklanding()
    {
        

        if (Physics.Raycast(transform.position, Vector3.down, (controller.height / 2) + 0.1f))
        {
            
            anim.SetBool("landing" , true);
            

        }



        if (Physics.Raycast(transform.position, Vector3.down, (controller.height / 2) + 0.1f))
        {

          
            anim.SetBool("landing", true);


        }


       
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
            
           
            groundedtimer = 0.08f;
            anim.SetFloat("groundedtimer", 0.08F);
            return true; 
            
        }



        if (Physics.Raycast(RightRayStart, Vector3.down, (controller.height / 2) + 0.1f))
        {
           
            
            groundedtimer = 0.08f;
            anim.SetFloat("groundedtimer", 0.08F);
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
        var centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.alignment = TextAnchor.UpperCenter;
        if (isDead)
        {
            var clones = GameObject.FindGameObjectsWithTag("Taco");
            foreach (var clone in clones)
            {
                Destroy(clone);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                player.transform.position = respawnPoint.transform.position;
                Instantiate(Taco, new Vector3(12, 0, -1), Quaternion.identity);
                Instantiate(Taco, new Vector3(-9.85f, 7.96f, -1), Quaternion.identity);
                Instantiate(Taco, new Vector3(12.13f, 12.07f, -1), Quaternion.identity);
                Instantiate(Taco, new Vector3(-37.84f, 3.74f, -1), Quaternion.identity);
                Instantiate(Taco, new Vector3(-39.1f, 23.44f, -1), Quaternion.identity);
                Instantiate(Taco, new Vector3(-18.26f, 1.7f, -1), Quaternion.identity);
                LevelManager.tacosCollected = 0;
                Time.timeScale = 1.0f;
                isDead = false;

            }
            string respawnText = "OOPS, YOU DIED! \n Press R to retry or M to get to the main menu.";
            GUI.Box(new Rect(Screen.width/2 - 200, Screen.height/2 - 200, 400, 50), respawnText);
            string tacoText = "Total tacos: " + LevelManager.tacosCollected;
            GUI.Box(new Rect(Screen.width/2 - 65, Screen.height/2 - 100, 130, 25), tacoText);
            string livesText = "Lives spent: " + LevelManager.lives;
            GUI.Box(new Rect(Screen.width/2 - 65, Screen.height/2 - 0, 130, 25), livesText);
        }
    }

    private void HandleLayers(){

        if (!IsControllerGrounded())
        {

            anim.SetLayerWeight(1, 1);
        }
        else {

            anim.SetLayerWeight(1, 0); 


        }


    }
}
