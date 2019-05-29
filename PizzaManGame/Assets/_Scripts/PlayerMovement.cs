using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float fall_Multiplier = 3f;
    public float lowJump_Multiplier = 25f;
    Rigidbody2D rb;
    public int player_Speed = 10;
    public bool facing = true;
    public int player_Jump = 1400;
    public float moveX;
    public bool isGrounded = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fall_Multiplier - 1) * Time.deltaTime;
            isGrounded = false;
        }
        else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJump_Multiplier - 1) * Time.deltaTime;
          
        }

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
        if(collision.gameObject.tag == "Enemy")
        {
         
        }
    }
    private void FixedUpdate()
    {
        PlayerRaycast();
    }

    void PlayerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if(hit.distance < 5f & hit.collider.tag=="Enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1500);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1300);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale=17;
            hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled=false;
            hit.collider.gameObject.GetComponent<CapsuleCollider2D>().enabled=false;
            hit.collider.gameObject.GetComponent<EnemyMovement>().enabled=false;

        }
        if (hit.distance < 0.4f && hit.collider.tag != "Enemy")
        {
            isGrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        
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
