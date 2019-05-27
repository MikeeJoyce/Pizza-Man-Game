using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerPoints : MonoBehaviour
{
    private float timer = 180;
    public int points=0;
    
    // Update is called once per frame
    void Update()
    {
        //Tick 1 second at a time
        timer -= Time.deltaTime;
        //Restarts the game when timer ends
        if (timer < 0.1f)
        {
            SceneManager.LoadScene("Level-1");
        }
    }
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        switch(trigger.gameObject.name)
        {
            case "Potato":
                points += 200;
                Destroy(trigger.gameObject);
                break;
            case "Pineapple":
                points += 200;
                Destroy(trigger.gameObject);
                break;
            case "Ham":
                points += 200;
                Destroy(trigger.gameObject);
                break;
            case "Cheese":
                points += 200;
                Destroy(trigger.gameObject);
                break;
        }
        TotalPoints();
    }

    void TotalPoints()
    {
        points = points + (int)( timer * 20 );
    }
}
