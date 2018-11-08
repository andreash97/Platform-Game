using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAccel : MonoBehaviour
{

    public float Speed = 0.1f;
    public float JumpHeight = 2f;
    private Rigidbody joseRB;
    private Vector3 joseInputs = Vector3.zero;
    public bool isGrounded;




    void Start()
    {
        joseRB = GetComponent<Rigidbody>();

    }


    void IsGrounded()
    {
        if (Physics.Raycast(transform.position, (-transform.up) + transform.right, 0.73F))
        {
            isGrounded = true;
        }
        else if (Physics.Raycast(transform.position, (-transform.up) + (-transform.right), 0.73F))
        {

            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }


    void Update()
    {
        IsGrounded();

        transform.position += transform.forward * Input.GetAxis("Horizontal") * Speed;


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            joseRB.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
        joseRB.MovePosition(joseRB.position + joseInputs * Speed * Time.fixedDeltaTime);
    }
}