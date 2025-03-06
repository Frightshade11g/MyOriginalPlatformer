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

    //float damageCounter;
    //[SerializeField] float damageTime = 0.75f;

    private int i; //index of array

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        boxCollider = GetComponent<BoxCollider2D>();
        enemyRb = GetComponent<Rigidbody2D>();
        currentTime = idleTime;
    }

    private void Update()
    {
        if(!stomped)
        {
            if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
            {
                currentTime -= Time.deltaTime;
                if (currentTime <= 0)
                {
                    i++;  // increases the index
                    currentTime = idleTime;
                    gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                    if (i == points.Length) //check if the platform reached the final point in the array
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
            if (transform.position.y < collision.transform.position.y - 1.5f)
            {
                stomped = true;
                boxCollider.enabled = false;
                enemyRb.constraints = RigidbodyConstraints2D.None;
                gameObject.transform.rotation = Quaternion.Euler(180, 0, 0);
            }

            else
            {
                player.TakeDamage(20);
            }
        }
    }
}
