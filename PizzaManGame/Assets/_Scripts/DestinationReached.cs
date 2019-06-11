using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestinationReached : MonoBehaviour
{
    static int countIngredients;
    private void Update()
    {
        countIngredients = PlayerPoints.countIngredients;

    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.name == "EndGame")
        {
            if (countIngredients <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
