using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb;
    private CapsuleCollider2D col;
    MovingPlatforms movingPlatforms;
    [SerializeField] GameOver[] gameover;
    [SerializeField] Canvas canvasObject;
    [SerializeField] private SpriteRenderer spriteRend;
    [SerializeField] private LayerMask groundlayerMask;

    [Header("Jumping Variables")]
    [SerializeField] float jumpVelocity = 10f;
    private float fallGravityScale = 6f;
    private float gravityScale = 4f;

    [Header("Variable Jump Height")]
    private bool jumping;
    private float buttonPressedTime;
    [SerializeField] float buttonPressWindow;
    private float jumpCutGravityMultiplier = 12;

    [Header("Coyote Time/Jump Buffering")]
    [SerializeField] private float coyoteTime = 0.2f;
    private float coyoteTimeCounter; //if you are grounded, this variable = 0.2, but if you fall of a ledge, this varibalbe starts to count down. This way, the variable can be > 0 for a perod of 0.2 seconds after falling off a ledge to enable the player to jump slightly right after falling off the legde

    [SerializeField] private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter; //if you press spacebar, this variable is set to 0.2 regardless of if you are already jumping or not. This way, if you press space 0.2 seconds before hitting the ground, you will jump once you hit the ground. Or if you're already on the ground, after pressing space, this variable will be set to 0.2 enabling the character to jump while on the ground.

    [Header("Movement Variables")]
    [SerializeField] float moveSpeed = 10f;

    [Header("Health Variables")]
    public HealthBar healthBar;
    private int maxHealth = 100;
    public int currentHealth;

    [Header("IFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] int numberOfFlashes;

    public bool isDead = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        movingPlatforms = FindAnyObjectByType<MovingPlatforms>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        gameover = FindObjectsOfType<GameOver>();
        isDead = false;
        spriteRend.color = Color.white;
    }

    void Update()
    {
        JumpBuffer();
        CoyoteTimeChecker();
        Jump();
        HandleMovement();
        Animations();
        GameOver();
        StopMovement();
    }

    #region Healh Management

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        StartCoroutine(Invunerability());
    }

    void GameOver()
    {
        if (currentHealth <= 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            foreach (GameOver gameOver in gameover)
            {
                gameOver.SetToTrue();
            }
            isDead = true;
            canvasObject.enabled = false;
        }
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(6, 8, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.66666f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }

    void StopMovement()
    {
        if (isDead)
        {
            StopAllCoroutines();
            spriteRend.color = new Color(1, 0, 0, 0.66666f);
        }
    }

    #endregion

    #region Jumping

    public bool IsGrounded()
    {
        RaycastHit2D rayCastHit2D = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, 0.01f, groundlayerMask);
        return rayCastHit2D.collider != null;
    }

    private void CoyoteTimeChecker()
    {
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }

    private void JumpBuffer()
    {
        if(!isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpBufferCounter = jumpBufferTime;
            }
            else
            {
                jumpBufferCounter -= Time.deltaTime;
            }
        }
    }

    private void Jump()
    {
        if (coyoteTimeCounter > 0f) //!jumping used to be here but it didn't work because jumping only becomes false if the y velcocity is less than 0 , so falling downward. But if you release then press space fast enough before the player starts falling, you can spam the jump for a second time while in the air.
        {   
            if (!jumping && jumpBufferCounter > 0f)
            {
                coyoteTimeCounter = 0f;
                jumping = true;
                jumpBufferCounter = 0f;
                rb.gravityScale = gravityScale;
                rb.velocity = Vector2.up * jumpVelocity;
                buttonPressedTime = 0f;
            }
            else if (jumping)
            {
                coyoteTimeCounter = 0f;
            }
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
    }

    #endregion

    #region Movement

    private void HandleMovement()
    {
        if(!isDead)
        {
            if (Input.GetKey(KeyCode.A))
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
