using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class PowerButton : MonoBehaviour
{
    //boolean determining if the moniter is on
    bool on;
    //float for distance button depresse
    public float depression = 0.8f;
    //float value to create phases for button behaviour
    public float time = 0;
    //float determining time till button returns to orignial position
    public float delay = 5;
    //float to create timer when button is pressed
    float clock = 0;

    // Start is called before the first frame update
    void Start()
    {
        //power is off at the start
        on = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if statement determining when the power has been turned on
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //reverse boolean state
            on = ! on;
        }

        //if statement depressing button upon input of space key
        if(Input.GetKeyDown(KeyCode.Space) && time == 0)
        {
            //update button y position by depression
            Vector3 pos = transform.position;
            pos.y -= depression;
            transform.position = pos;

            //set button state to time 1
            time = 1;
        }
        //if statement for state time 1 where button runs timer to delay return to original position
        if(time == 1)
        {
            //timer till state change to time 2
            clock += 10 * Time.deltaTime;

                //if statement updating state to time 2 when timer surpasses delay value
                if(clock > delay)
            {
                time = 2;
            }
        }

        //if statement for state time 2 to reset values and position
        if(time == 2)
        {
            //reset button position
            Vector3 pos = transform.position;
            pos.y += depression;
            transform.position = pos;
            //reset clock to 0
            clock = 0;
            //reset time state to time 0
            time = 0;
        }

        
    }
}
