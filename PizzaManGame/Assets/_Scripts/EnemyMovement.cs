using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public int EnemySpeed=2;
    public bool facing = true;
    public int xMove=1;
    public AudioClip kill;
    AudioSource audioSource;
    // Start is called before the first frame update

    void Awake()
    {

        audioSource = GetComponent<AudioSource>();
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMove, 0));
        RaycastHit2D left = Physics2D.Raycast(transform.position, new Vector2(-1, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMove, 0) * EnemySpeed;

        if(hit.distance < 0.4f)
        {
            Flip();
            FlipEnemy();
        }
        if ((hit.distance < 0.7f && hit.collider.tag == "Player") || (left.distance<.07f && hit.collider.tag == "Player"))
        {
            audioSource.PlayOneShot(kill, 1);
            PlayerPoints.points = 0;
            Destroy(hit.collider.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

