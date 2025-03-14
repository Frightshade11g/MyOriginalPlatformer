using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGravityControl : MonoBehaviour
{
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Trigger"))
        {
            Destroy(rb);
        }
    }
}
