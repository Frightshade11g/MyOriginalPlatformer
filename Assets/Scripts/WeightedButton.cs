using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class WeightedButton : MonoBehaviour
{
    public GameObject thisObject;
    Rigidbody2D rbb;
    public BoxCollider2D boxcol;
    [SerializeField] GameObject door;

    private void Awake()
    {
        rbb = thisObject.GetComponent<Rigidbody2D>();
        rbb.gravityScale = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Button Pressed");
            rbb.gravityScale = 1f;
            door.SetActive(false);
        }
    }
}
