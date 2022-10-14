using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControll : MonoBehaviour
{
    //basic movement
    private float horizontal;
    public float speed;
    public float jumpPower = 16f;
    private bool isFacingRight = true;
    public Animator animator;
    private bool doubleJump;
    //dashing mechanic
    public bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.65f;
    //speeding up mechanic
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedMilestoneCount;
    //coyote time aka jump even when not on ground + buffering
    public float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    //jump buffer time!!! (yay)
    public float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    public LevelManager theLevelManager;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] public TrailRenderer tr;
            







    // Update is called once per frame
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (isDashing)
        {
            return;
        }

        animator.SetBool("Jump", !IsGrounded());



        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("Jump", true);
        }


        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }


        if (coyoteTimeCounter > 0f && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);

                doubleJump = !doubleJump;
            }
        }
        //jump sensitivity
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }
        //press shift = do function (dash) 
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
        //speed increaser 
        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speed = speed * speedMultiplier;
        }


        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Flip();
    }

   

    

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }


        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal >0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {

            theLevelManager.RestartGame();
            canDash = true;
            speed = 6f;
        }
    }


} 

