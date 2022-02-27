using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2;

    public float jumpSpeed = 3;

    Rigidbody2D rb2D;

    public bool betterJump = false;

    public float fallMultiplier = 0.5f;

    public float lowJumpMultiplier = 1f;

    private bool Grounded;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

    }


    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        Debug.DrawRay(transform.position, Vector3.down * 0.19f, Color.red);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.19f))
        {
            Grounded = true;
        }
        else Grounded = false;


        if (Input.GetKey("space") && Grounded )
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }

        //if (betterJump)
        //{
        //    if (rb2D.velocity.y < 0)
        //    {
        //        rb2D.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier) * Time.deltaTime;
        //    }

        //    if (rb2D.velocity.y > 0 )
        //    {
        //        rb2D.velocity += Vector2.up * Physics.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
        //    }
        //}
    }
}
