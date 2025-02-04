using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformDetector : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points; //An array of trasform points

    [SerializeField] GameObject player;

    private int i; //index of array

    private void Awake()
    {
        transform.position = points[startingPoint].position;
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;  // increases the index
            if (i == points.Length) //check if the platform reached the final point in the array
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            collision.transform.SetParent(transform);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
                collision.transform.SetParent(null);
        }
    
        else
        {
                collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
            if (player == null) return;
            collision.transform.SetParent(null);
    }
}
