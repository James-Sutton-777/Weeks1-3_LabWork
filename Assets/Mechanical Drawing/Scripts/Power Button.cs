using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerButton : MonoBehaviour
{
    //boolean determining if the moniter is on
    bool on;
    //float for distance button depresse
    public float depression = 0.5f;
    //float value to create phases for button behaviour
    public float time = 0;
    //float determining time till button returns to orignial position
    public float delay = 5;
    //float to create timer when button is pressed
    float clock = 0;

    // Start is called before the first frame update
    void Start()
    {
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

    }
}
