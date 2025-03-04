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
}
