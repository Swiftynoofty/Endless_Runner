using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public float runSpeed = 10f;
    float horizontalMove = 0f;
    bool jump = false;
    public float fallForce = -10f;
    bool fall = false;
    public Animator animator;   
    

   



    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true; 

        }
        if (Input.GetKey(KeyCode.S))
        {
            fall = true;
        }
 
    }


    void FixedUpdate ()
    {

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

    }
}       
