using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb;
    private CapsuleCollider2D col;

    [Header("Jumping Variables")]
    [SerializeField] float jumpVelocity = 10f;
    [SerializeField] private LayerMask groundlayerMask;
    private float fallGravityScale = 6f;

    [Header("Variable Jump Height")]
    private bool jumping;
    private float buttonPressedTime;
    private float jumpCutGravityMultiplier = 12;
    [SerializeField] float buttonPressWindow;
    private float gravityScale = 4f;

    [Header("Coyote Time/Jump Buffering")]
    [SerializeField] private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    private bool jumpBuffered = false;

    [SerializeField] private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    [Header("MovementVariables")]
    Vector2 moveVelocity;
    [SerializeField] float moveSpeed = 10f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        JumpBuffer();
        CoyoteTimeChecker();
        Jump();
        HandleMovement();
        Animations();
    }

    #region Jumping

    private bool IsGrounded()
    {
        RaycastHit2D rayCastHit2D = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, 0.01f, groundlayerMask);
        return rayCastHit2D.collider != null;
    }

    private void CoyoteTimeChecker()
    {
        if (IsGrounded())
        {
            jumpBuffered = false;
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }

    private void JumpBuffer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsGrounded())
            {
                jumpBuffered = true;
            }
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
    }

    private void Jump()
    {
        //if (!jumpBuffered)
        //{
            if ((coyoteTimeCounter > 0f && jumpBufferCounter > 0f) && !jumping)
            {
                coyoteTimeCounter = 0f;
//                if (jumping) // don't let me spam the jump
//                {
                   // return; // exit the jump method right away.
//                }
                jumpBuffered = true;
                jumpBufferCounter = 0f;
                rb.gravityScale = gravityScale;
                rb.velocity = Vector2.up * jumpVelocity;
                jumping = true;
                buttonPressedTime = 0f;
            }

            if (jumping)
            {
                buttonPressedTime += Time.deltaTime;

                if (buttonPressedTime < buttonPressWindow && Input.GetKeyUp(KeyCode.Space))
                {
                    rb.gravityScale = jumpCutGravityMultiplier;
                }
                if (rb.velocity.y < 0)
                {
                    rb.gravityScale = fallGravityScale;
                    jumping = false;
                }
            }
        //}
    }

    #endregion

    #region Movement

    private void HandleMovement()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }

    #endregion

    #region Animations

    private void Animations()
    {
        if(IsGrounded())
        {
            if(rb.velocity.x == 0)
            {
                //Idle Animation
            }
            else
            {
                //play Movement animations based on the vector 2's direction
            }
        }
        else
        {
            //Jump animation
        }
    }

    #endregion 
}
