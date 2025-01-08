using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class WeightedButton : MonoBehaviour
{
    public GameObject thisObject;
    Rigidbody2D rbb;
    public BoxCollider2D boxcol;

    private void Awake()
    {
        rbb = thisObject.GetComponent<Rigidbody2D>();
        rbb.gravityScale = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == boxcol && collision.gameObject.CompareTag("Player"))
        {
            rbb.gravityScale = 1f;
        }
    }
}
