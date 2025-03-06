using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerButton : MonoBehaviour
{
    [SerializeField] private Door door;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            door.OpenDoor();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            //doorSetActive.CloseDoor();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Button"))
        {
            door.OpenDoor();
        }
    }
}
