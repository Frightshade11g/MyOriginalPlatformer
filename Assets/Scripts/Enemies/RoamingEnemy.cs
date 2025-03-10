using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamingEnemy : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points; //An array of trasform points
    float currentTime;
    [SerializeField] float idleTime = 2f;

    [SerializeField] Player player;
    BoxCollider2D boxCollider;
    Rigidbody2D enemyRb;
    bool stomped;

    [SerializeField] float bounce;
    [SerializeField] float addedBounce;

    private int i; //index of array

    private void Awake()
    {
        //player = FindObjectOfType<Player>();
        boxCollider = GetComponent<BoxCollider2D>();
        enemyRb = GetComponent<Rigidbody2D>();
        currentTime = idleTime;
    }

    private void Update()
    {
        if(!stomped) //if the player stomps on the enemy, the enemy dies and falls off-screen
        {
            if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
            {
                currentTime -= Time.deltaTime;
                if (currentTime <= 0)
                {
                    i++;  // increases the index
                    currentTime = idleTime;
                    gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                    if (i == points.Length) //check if the enemy reached the final point in the array (There's only two points but I copied this code from the moving platform to save time)
                    {
                        i = 0;
                        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                }
            }

            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }

        if(transform.position.y < -20f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (transform.position.y > collision.transform.position.y - 1.4f) //Damages player and adds a knockback effect for polish
            {
                if (collision.collider.CompareTag("Player"))
                {
                    player.TakeDamage(20);
                    if(player.IsGrounded() == true)
                    {
                        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * addedBounce, ForceMode2D.Impulse);
                    }
                    else
                    {
                        collision.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * bounce, ForceMode2D.Impulse);
                    }
                }
            }

            else //Kills the enemy if the player jumps on top of the enemy
            {
                stomped = true;
                boxCollider.enabled = false;
                enemyRb.constraints = RigidbodyConstraints2D.None;
                gameObject.transform.rotation = Quaternion.Euler(180, 0, 0);
            }
        }
    }
}
