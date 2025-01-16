using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public List<Transform> waypoints;
    public float movespeed;
    public int target;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[target].position, movespeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if(transform.position == waypoints[target].position)
        {
            if(target == waypoints.Count - 1)
            {
                target = 0;
            }
            else
            {
                target += 1;
            }
        }
    }
}
