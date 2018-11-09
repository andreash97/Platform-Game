using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour {
    // shooting 
    
    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public float Bullet_Force;
    public float Fire_rate;
    
    

    // Rotation 
    
    public float Rot_Smoothness;
    private Quaternion originalrot;
    private Transform player;
    private Quaternion Q_rot_from;
    private Quaternion Q_rot_to;
    private bool rotate;

    // Finds player and reads original rotation
    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        originalrot = transform.rotation;
    }

    void Update()
    {
         // Rotates the turret towards the player.
        if (rotate == true)
        {

            Vector3 dir = player.position - transform.position ;
            float angle = Mathf.Atan2(dir.y, dir.z) * Mathf.Rad2Deg;
            Q_rot_from = transform.rotation;
            Q_rot_to = Quaternion.AngleAxis(angle, Vector3.left);
            transform.rotation = Quaternion.Lerp(Q_rot_from, Q_rot_to, Time.deltaTime * Rot_Smoothness);
          
        }
        // Rotates the turret back to original rotation
        if (rotate == false)
        {
            
            Q_rot_from = transform.rotation;
            transform.rotation = Quaternion.Lerp(Q_rot_from, originalrot, Time.deltaTime * Rot_Smoothness);
        }
       


    }
   // turret in range of player, activates rotation and shoots towards player
   void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            StartCoroutine("Shoot");
            rotate = true;

        }
    }
   // turret out of range, deactivates and rotates back to original position
  void OnTriggerExit(Collider other) 
    {
        if (other.tag =="Player")
        {
            StopCoroutine("Shoot"); 
            rotate = false;
            
        }
    }
    
    IEnumerator Shoot()
    {
        while (true)
        {
            
            
            
            //Instantiating the bullet.
            GameObject Temporary_Bullet_Handler;    
            Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation);

            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
             Rigidbody Temporary_RigidBody;      
             Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
            
            
            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

            //Pushes Bullet forward by set Force
            Temporary_RigidBody.velocity = transform.forward * Bullet_Force;  

            // Waits to repeate method by set "Fire_rate"
            yield return new WaitForSeconds(Fire_rate);

        }
        
    }
    
}

