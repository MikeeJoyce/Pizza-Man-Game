using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int EnemySpeed=5;
    public bool facing = true;
    public int xMove=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Flip()
    {
        if(xMove > 0)
        {
            xMove = -1;
        }
        else
        {
            xMove = 1; 
        }
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMove, 0) * EnemySpeed;

        if (xMove > 0.0f && facing == false)
        {
            FlipEnemy();
        }
        else if (xMove < 0.0f && facing == true)
        {
            FlipEnemy();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Flip")
        {
            Flip();
        }   
    }

    void FlipEnemy()
    {
        facing = !facing;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}

