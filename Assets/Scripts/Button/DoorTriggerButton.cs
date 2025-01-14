using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerButton : MonoBehaviour
{
    [SerializeField] private DoorSetActive doorSetActive;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            doorSetActive.OpenDoor();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            doorSetActive.CloseDoor();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Button"))
        {
            doorSetActive.OpenDoor();
        }
    }
}
