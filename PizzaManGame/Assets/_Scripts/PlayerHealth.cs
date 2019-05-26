using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{

    public bool death;
    public int health;
    // Start is called before the first frame update

    void Start()
    {
        death = false;   
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            SceneManager.LoadScene("Level-1");
        }
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Level-1");
         
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
