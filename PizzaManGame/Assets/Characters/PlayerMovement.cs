using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public int playerSpeed = 10;
    public bool facingRight = true;
    public int playerJump = 1250;
    public float moveX;

    void Update()
    {
        PlayerMove();
    }


    void PlayerMove()
    {
        //Controls
        moveX = Input.GetAxis("Horizontal");

        //Direction

        if(moveX > 0.0f && facingRight== false)
        {
            FlipPlayer();
        }
        else if (moveX < 0.0f && facingRight == true)
        {
            FlipPlayer();
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJump);
    }
}
