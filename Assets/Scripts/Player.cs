using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {
    private float inputDirection;  // X component of the vector 
    private float verticalVelocity;  // Y component of the vector
    private Vector3 moveVector;
    private bool secondJumpAvail;

    private float speed = 5.0f;
    private float gravity = 25.0f;

    private CharacterController controller;
    private bool facingleft;
    private Animator anim;
    public bool isDead = false;
    public bool NPCRestart;
    public static int savedtacos;
    private float pressJump;
    private float groundedtimer;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        facingleft = true;
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Level 1" || currentScene.name == "Level 1 Easy")
        {
            FindObjectOfType<TacoSpawner>().TacoLevel1List();
        }
        if (currentScene.name == "BossFight")
        {
            FindObjectOfType<TacoSpawner>().TacoBossList();
        }
    }

    // Update is called once per frame
    public void Update() {
        IsControllerGrounded();
        inputDirection = -Input.GetAxisRaw("Horizontal") * speed;
        Flip(inputDirection);
        HandleLayers();
  
        if (isDead)
        {
            Time.timeScale = 0f;
        }

        groundedtimer -= Time.deltaTime; // makes it so that edge jumping is smoother by making you grounded alittle longer than in reality.
        pressJump -= Time.deltaTime;    // makes it so that if you press jump button right before landing you will infact jump.

        if (Input.GetKeyDown(KeyCode.W))
        {
            pressJump = 0.15f;
            
        }

        if (groundedtimer >0) 
        {
            anim.ResetTrigger("fallingjump");
            anim.ResetTrigger("firstjump");
            verticalVelocity = 0;
            secondJumpAvail = true;
            if (pressJump > 0)
            {
                anim.SetFloat("groundedtimer", 0);
                anim.SetTrigger("firstjump");
                groundedtimer = 0;
                pressJump = 0;
                verticalVelocity = 10;
                FindObjectOfType<LevelManager>().Jump();
            }
        } 
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (secondJumpAvail)
                {
                    anim.SetFloat("groundedtimer", 0);
                    verticalVelocity = 10;
                    anim.SetTrigger("fallingjump");
                    FindObjectOfType<LevelManager>().Jump();
                    groundedtimer = 0;
                    pressJump = 0;
                    secondJumpAvail = false;
                }
            }
        }
        moveVector = new Vector3(inputDirection, verticalVelocity, 0);
        controller.Move(moveVector * Time.deltaTime);
        anim.SetFloat("speed", Mathf.Abs(inputDirection));
    }

    private bool IsControllerGrounded()
    {
        Vector3 leftRayStart;
        Vector3 RightRayStart;

        leftRayStart = controller.bounds.center;
        RightRayStart = controller.bounds.center;

        leftRayStart.x -= controller.bounds.extents.x;
        RightRayStart.x += controller.bounds.extents.x;


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
                FindObjectOfType<LevelManager>().Taco();
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
            FindObjectOfType<LevelManager>().Dead();
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
            if (Input.GetKeyDown(KeyCode.R))
            {
                Restart();
                
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene("Menu");
            }
            FindObjectOfType<LevelManager>().DeadOnGUI();
        }
    }

    public void Restart()
    {
        FindObjectOfType<LevelManager>().Spawn();
        LevelManager.tacosCollected = savedtacos;
        isDead = false;
        secondJumpAvail = false;
        NPCRestart = true;
        verticalVelocity = 0;
        groundedtimer = 0;
        Time.timeScale = 1.0f;
        anim.SetTrigger("restart");
        Scene currentScene = SceneManager.GetActiveScene();
         if (!facingleft)
        {
            facingleft = !facingleft;
            Vector3 thescale = transform.localScale;
            thescale.z *= -1;
            transform.localScale = thescale;
        }
        var clones = GameObject.FindGameObjectsWithTag("Taco");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
        if (currentScene.name == "Level 1" || currentScene.name == "Level 1 Easy")
        {

            FindObjectOfType<TacoSpawner>().TacoLevel1List();
        }
        if (currentScene.name == "BossFight" || currentScene.name == "BossFight Easy")
        {
            FindObjectOfType<TacoSpawner>().TacoBossList();
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
