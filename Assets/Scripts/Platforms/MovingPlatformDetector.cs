using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformDetector : MonoBehaviour
{
    [SerializeField] private Player playerScript;
    public Transform player;
    public bool check = false;
    RaycastHit2D hit;

    void Update()
    {
        //Change to extrapolate if player is colliding with moving platform
        if (playerScript.IsGrounded() == false)
        {
            check = false;
            if(Input.GetAxisRaw("Horizontal") > 0.25f || Input.GetAxisRaw("Horizontal") < 0.25f)
            {
                player.SetParent(null);
            }
        }

        if (check != true)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.down, 0.125f);


            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("MovingPlatform"))
                {
                    player.SetParent(hit.transform);
                    //playerScript.rb = Rigidbody2D.set.Extrapolate     //<<< This
                    check = true;
                }
                else
                {
                    player.SetParent(null);
                }
            }
        }
    }
}
