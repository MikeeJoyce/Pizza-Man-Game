using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerPoints : MonoBehaviour
{
    private float timer = 180;
    public static int points = 0;
    public GameObject timerUI;
    public GameObject scoreUI;
    public GameObject ingredientsUI;
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
        ingredientsUI.gameObject.GetComponent<Text>().text = ("Ingredients left: " + (int)countIngredients);
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
        //Used this to try limit it to picking it only 1 time, instead of multiple frames 
        if (isInCollision == false)
        {
            isInCollision = true;
            //Do stuff

            switch (trigger.gameObject.name)
            {
                //Takes 1 away from the total , adds points , and debug is for our testing purposes only
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
                        //For our testing only
                        Debug.Log("Not collected all ingr");
                    }
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
