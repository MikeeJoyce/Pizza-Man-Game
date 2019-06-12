/* Basic camera controller for our game, follows our character 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{

    public GameObject player;

    //Control the x and y axis of the camera
    public float x_Min;
    public float x_Max = 40;

    public float y_Min =-40;
    public float y_Max = 40;
    // Start is called before the first frame update

    void Start()
    {
        //Access player tagged
        player = GameObject.FindGameObjectWithTag("Player");    


    }

    // Update is called once per frame
    void LateUpdate()
    {
        float x = Mathf.Clamp(player.transform.position.x,x_Min, x_Max);
        float y = Mathf.Clamp(player.transform.position.y,y_Min, y_Max);
        //Set the 
        gameObject.transform.position = new Vector3(x, y,gameObject.transform.position.z);
    }
}
