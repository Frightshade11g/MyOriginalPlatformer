using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    Player player;
    bool bounced = false;
    [SerializeField] float bounce = 0.1f;
    [SerializeField] float AddedBounce = 20f;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.TakeDamage(20);

        if (!bounced)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (transform.position.y < collision.transform.position.y - 1f)
                {
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * player.GetComponent<Rigidbody2D>().velocity.y * AddedBounce, ForceMode2D.Impulse);
                }

                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
                bounced = true;
            }

            //if collided & pressed jump { jump higher } stretch goal
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
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
