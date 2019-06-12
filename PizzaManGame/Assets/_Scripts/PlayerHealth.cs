using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public AudioClip kill;
    AudioSource audioSource;
    public bool death;
    public int health;
    // Start is called before the first frame update

    void Start()
    {
        death = false;   
    }

    void Awake()
    {

        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            audioSource.PlayOneShot(kill, 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
