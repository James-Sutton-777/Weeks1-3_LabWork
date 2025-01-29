using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    //boolean determining if the moniter is on
    bool on;

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
           on =! on;
        }

        //if statement controlling behaviour when power is on
        if (on == true)
        {
            Debug.Log("ON");
        }
        //when the power has been turned off
        else
        {
            Debug.Log("OFF");
        }
    }
}
