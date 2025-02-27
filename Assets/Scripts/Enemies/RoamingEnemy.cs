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

    float damageCounter;
    [SerializeField] float damageTime = 0.75f;

    private int i; //index of array

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        currentTime = idleTime;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                i++;  // increases the index
                currentTime = idleTime;
                if (i == points.Length) //check if the platform reached the final point in the array
                {
                    i = 0;
                }
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (transform.position.y < collision.transform.position.y - 1.5f)
            {
                Destroy(gameObject);
            }

            else
            {
                player.TakeDamage(20);
            }
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
      if(damageCounter > 0)
      {
          damageCounter -= Time.deltaTime;
      }

      if (damageCounter <= 0)
      {
          player.TakeDamage(20);
          damageCounter = damageTime;
      }

    }
}
