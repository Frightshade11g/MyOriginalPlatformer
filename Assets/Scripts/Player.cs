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

    [Header("MovementVariables")]
    Vector2 moveVelocity;

    void Awake()
    {
        playerBase = GetComponent<Player_Base>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        //boxCol = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Jump();
        GravityControls();
    }

    #region Jumping

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }
    }

    private void GravityControls()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity += (Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime) * Vector2.up;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D rayCastHit2D = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, 0.1f, groundlayerMask);
        Debug.Log("WORK");
        return rayCastHit2D.collider != null;
    }

    #endregion

    #region Movement



    #endregion
}
