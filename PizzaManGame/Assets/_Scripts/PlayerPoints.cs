using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerPoints : MonoBehaviour
{
    private float timer = 180;
    static int points = 0;
    public GameObject timerUI;
    public GameObject scoreUI;
    bool isInCollision = false;
    bool collectAll = false;

    // Update is called once per frame
    void Update()
    {
        //Tick 1 second at a time
        timer -= Time.deltaTime;
        timerUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timer);
        scoreUI.gameObject.GetComponent<Text>().text = ("Score: " + (int)points);
        //Restarts the game when timer ends
        if (timer < 0.1f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
   
        //Collecting all ingredients, and increasing score
        if (isInCollision == false)
        {
            isInCollision = true;
            //Do stuff

            switch (trigger.gameObject.name)
            {
                case "Potato":
                    Destroy(trigger.gameObject);
                    points += 200;

                    break;
                case "Pineapple":

                    Destroy(trigger.gameObject);
                    points += 200;

                    break;
                case "Ham":
                    Destroy(trigger.gameObject);
                    points += 200;

                    break;
                case "Cheese":
                    Destroy(trigger.gameObject);
                    points += 200;

                    break;
                case "house":
                    //Check to see if all ingredients found
                    if (collectAll == true)
                    {
                        TotalPoints();
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                    else
                    {
                        Debug.Log("Not collected all ingr");
                    }
                    break;

            }
        }
        else
            isInCollision = false;
        
    }
    //Check if collected all the ingredients
    private void FixedUpdate()
    {
        
        if (GameObject.FindWithTag("Ingredient") == null)
        {
            collectAll = true;
        }
    }

    void TotalPoints()
    {
        points = points + (int)( timer * 20 );
    }
}
