using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    [SerializeField] private float bounce = 20f;
    private bool bounced;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!bounced)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
                bounced = true;
            }

            //if collided & pressed jump { jump higher } stretch goal
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (bounced)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                bounced = false;
            }
        }
    }

}
