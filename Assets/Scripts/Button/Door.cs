using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] float speed;
    //[SerializeField] int startingPoint;
    [SerializeField] Transform point;
    bool doorSlide = false;

    public void OpenDoor()
    {
        doorSlide = true;
        //gameObject.SetActive(false);
    }
    private void Update()
    {
        if(doorSlide == true)
        {
            if (Vector2.Distance(transform.position, point.position) > 0.02f)
            {
                transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
            }
        }
    }
}
