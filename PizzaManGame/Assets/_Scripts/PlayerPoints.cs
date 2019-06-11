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
    static public int countIngredients;

    private void Awake()
    {
        countIngredients = GameObject.FindGameObjectsWithTag("Ingredient").Length;
    }
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
            points = 0;
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
                    countIngredients--;
                    Debug.Log(countIngredients);
                    break;
                case "Pineapple":

                    Destroy(trigger.gameObject);
                    points += 200;
                    countIngredients--;
                    Debug.Log(countIngredients);
                    break;
                case "Ham":
                    Destroy(trigger.gameObject);
                    points += 200;
                    countIngredients-- ;
                    Debug.Log(countIngredients);
                    break;
                case "Cheese":
                    Destroy(trigger.gameObject);
                    points += 200;
                    countIngredients-- ;
                    Debug.Log(countIngredients);
                    break;
                case "EndGame":
                    //Check to see if all ingredients found
                    if (countIngredients <= 0)
                    {
                        TotalPoints();
                    }
                    else
                    {
                        Debug.Log("Not collected all ingr");
                    }
                    break;

                case "spike":
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    break;

            }
        }
        else
            isInCollision = false;
        
    }
    //Check if collected all the ingredients

    void TotalPoints()
    {
        points = points + (int)( timer * 20 );
    }
}
