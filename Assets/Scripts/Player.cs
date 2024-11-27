using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    private Player_Base playerBase;
    private Rigidbody2D rb;
    private Collider2D col;

    [Header("Jumping Variables")]
    bool isGrounded;
    [SerializeField] float juniorJumpVelocity = 10f;

    [SerializeField] private LayerMask groundlayerMask;

    void Awake()
    {
        playerBase = GetComponent<Player_Base>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        Jump();
    }

    #region Jumping

    private void Jump()
    {
        if (InputManager.JumpWasPressed && IsGrounded())
        {
            rb.velocity = Vector2.up * juniorJumpVelocity;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D rayCastHit2D = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down * 0.1f, groundlayerMask);
        Debug.Log(rayCastHit2D.collider);
        return rayCastHit2D.collider != null;
    }

    #endregion
}
