using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerButton : MonoBehaviour
{
    [SerializeField] private Door door;
    SpriteRenderer spriteRend;
    [SerializeField] Sprite switched;

    private void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            door.OpenDoor();
            spriteRend.sprite = switched;
        }
    }
}
