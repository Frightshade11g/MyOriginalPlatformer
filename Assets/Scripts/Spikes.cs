using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    Player player;
    float damageCounter;
    [SerializeField] float damageTime = 2f;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        damageCounter = damageTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.TakeDamage(20);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(damageCounter > 0)
        {
            damageCounter -= Time.deltaTime;
        }
        if(damageCounter <= 0)
        {
            player.TakeDamage(20);
            damageCounter = damageTime;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        damageCounter = damageTime;
    }
}
