using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject groundChecker;
    public LayerMask whatIsGround;
    public float jumpForce;
    public float maxSpeed = 5.0f;
    bool isOnGround = false;
    bool issprint = false;

    

    Rigidbody2D playerObject;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxSpeed = 20.0f;
        } else
        {
            maxSpeed = 10.0f;
        }


        if (Input.GetKey(KeyCode.S))
        {
            playerObject.AddForce(new Vector2(0f, -10f));


        }


        float movementValueX = Input.GetAxis("Horizontal");

        playerObject.velocity = new Vector2 (movementValueX * maxSpeed, playerObject.velocity.y);//running/walking
        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 1.0f, whatIsGround);//jumpping


        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            playerObject.AddForce(new Vector2(0.0f, jumpForce));
        }
    }



    
}
