//Script used for floating tiles, very similar to our enemy movement
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTiles : MonoBehaviour
{
    public int EnemySpeed = 2;
    public bool facing = true;
    public int xMove = 1;
    // Start is called before the first frame update

    void Flip()
    {
        if (xMove > 0)
        {
            xMove = -1;
        }
        else
        {
            xMove = 1;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMove, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMove, 0) * EnemySpeed;

        if (hit.distance < 0.4f)
        {
            Flip();

        }

    }
}