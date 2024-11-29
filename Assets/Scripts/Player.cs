using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    private Player_Base playerBase;
    private Rigidbody2D rb;
    private Collider2D col;
    private BoxCollider2D boxCol;

    [Header("Jumping Variables")]
    [SerializeField] float jumpVelocity = 1000f;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier = 2.5f;

    [SerializeField] private LayerMask groundlayerMask;

    void Awake()
    {
        playerBase = GetComponent<Player_Base>();
        rb = GetComponent<Rigidbody2D>();
        //col = GetComponent<Collider2D>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Jump();
        //GravityControl();
    }

    #region Jumping

    private void Jump()
    {
        if (IsGrounded() && InputManager.JumpWasPressed)
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }
    }

    private void GravityControl()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += (Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime) * Vector2.up;
        }
    }
    private bool IsGrounded()
    {
        RaycastHit2D groundedRayCastHit2D = Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, 0.1f * Vector2.down, groundlayerMask);
        Debug.Log(groundedRayCastHit2D.collider);
        return groundedRayCastHit2D.collider != null;
    }

    #endregion
}
