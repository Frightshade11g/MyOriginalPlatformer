using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    private Player_Base playerBase;
    private Rigidbody2D rb;
    private CapsuleCollider2D col;
    //private BoxCollider2D boxCol;

    [Header("Jumping Variables")]
    [SerializeField] float jumpVelocity = 10f;
    [SerializeField] float fallMultiplier = 11f;
    //[SerializeField] float lowJumpMultiplier = 11f;
    [SerializeField] private LayerMask groundlayerMask;
    private float fallGravityScale = 6f;

    [Header("Variable Jump Height")]
    private bool jumping;
    private float buttonPressedTime;
    float jumpCutGravityMultiplier = 12;
    [SerializeField] float buttonPressWindow;
    private float gravityScale = 4f;

    [Header("MovementVariables")]
    Vector2 moveVelocity;
    [SerializeField] float moveSpeed = 10f;

    void Awake()
    {
        playerBase = GetComponent<Player_Base>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        Jump();
        //GravityControls();
        HandleMovement();
        Animations();
    }

    #region Jumping

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.gravityScale = gravityScale;
            rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            jumping = true;
            buttonPressedTime = 0;
        }

        if(jumping)
        {
            buttonPressedTime += Time.deltaTime;

            if(buttonPressedTime < buttonPressWindow && Input.GetKeyUp(KeyCode.Space))
            {
                rb.gravityScale = jumpCutGravityMultiplier;
            }
            if(rb.velocity.y < 0)
            {
                rb.gravityScale = fallGravityScale;
                jumping = false;
            }
        }
    }

    //private void GravityControls()
    //{
    //    if(rb.velocity.y < 0)
    //    {
    //        rb.velocity += (Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime) * Vector2.up;
    //    }
    //}

    private bool IsGrounded()
    {
        RaycastHit2D rayCastHit2D = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, 0.1f, groundlayerMask);
        Debug.Log("WORK");
        return rayCastHit2D.collider != null;
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
