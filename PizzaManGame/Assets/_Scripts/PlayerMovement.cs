using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public int player_Speed = 10;
    public bool facing = true;
    public int player_Jump = 1400;
    public float moveX;
    public bool isGrounded = true;

    private void FixedUpdate()
    {
        
    }
    void Update()
    {
        PlayerMove();
        PlayerRaycast();
    }

    void PlayerMove()
    {
        //Get input left or right keys
        moveX = Input.GetAxis("Horizontal");

      
        //Change direction depending which way you're moving
        if (moveX > 0.0f && facing == false)
        {
            FlipPlayer();
        }
        else if (moveX < 0.0f && facing == true)
        {
            FlipPlayer();
        }

        //call method when spacebar pressed
        if (Input.GetButtonDown("Jump") && isGrounded==true )
        {
            Jump();
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * player_Speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    //Jump method
    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * player_Jump);
        isGrounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void PlayerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if(hit.distance<0.5f && hit.collider.tag=="Enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1500);
        }
    }

    //Flip method when turning around
    void FlipPlayer()
    {
        facing = !facing;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
