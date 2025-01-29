using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformDetector : MonoBehaviour
{
    [SerializeField] private Player playerScript;
    public Transform player;
    //RaycastHit2D hit;

    //void Update()
    //{
    //    if(playerScript.moving == true)
    //    {
    //        player.SetParent(null);
    //    }
    //
    //    if (playerScript.moving == false)
    //    {
    //        hit = Physics2D.Raycast(transform.position, Vector2.down, 0.125f);
    //
    //        if (hit.collider != null)
    //        {
    //            if (hit.collider.CompareTag("MovingPlatform"))
    //            {
    //                player.SetParent(hit.transform);
    //            }
    //            else
    //            {
    //                player.SetParent(null);
    //            }
    //        }
    //    }
    //}


}
