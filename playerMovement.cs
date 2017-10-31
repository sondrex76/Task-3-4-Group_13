using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public int playerSpeed = 10;
    public bool right = true;
    public bool dJump = false;
    public bool uDown = false;
    public bool changeGravity = true;
    public int playerJumpPower = 5;
    public float moveX;
    public bool grounded = true;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    private Rigidbody2D rb;

    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody2D>();
    }
	// Update is called once per frame
	void Update () {
           playerMove();

        if (rb.velocity.y < 0)
        {
            if(!uDown)
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

            else
            rb.velocity -= Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump") && !dJump)
        {
            if(!uDown)
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

            else
                rb.velocity -= Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void playerMove()
    {

        moveX = Input.GetAxis("Horizontal");

        if(moveX < 0.0f && right)
        {
            flipPlayer();
        }
        else if (moveX > 0.0f && !right)
        {
            flipPlayer();
        }



        if(Input.GetKeyDown("space"))
        {
            if(grounded)
            jump();

            else if(!dJump)
            {
                doubleJump();
            }
        }


        if(Input.GetKeyDown("q"))
        {
            if(changeGravity)
            flipGravity();
        }

        if(Input.GetKeyDown("f"))
        {
            shoot();
        }

        rb.velocity = new Vector2(moveX * playerSpeed, rb.velocity.y);
    }

    void flipPlayer()
    {
        right = !right;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void flipGravity()
    {
        uDown = !uDown;
        changeGravity = false;

        Vector2 localScale = gameObject.transform.localScale;
        localScale.y *= -1;
        transform.localScale = localScale;

        rb.gravityScale *= -1;
    }

    void shoot()
    {

    }

    void jump()
    {
       
            if(!uDown)
            rb.velocity = Vector2.up * playerJumpPower;

            else
            rb.velocity = Vector2.up * playerJumpPower*-1;

        
    }

    void doubleJump()
    {
        dJump = true;
        jump();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            dJump = false;
            changeGravity = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
