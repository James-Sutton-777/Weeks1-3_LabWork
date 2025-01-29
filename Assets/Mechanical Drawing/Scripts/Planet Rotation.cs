using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlanetRotation : MonoBehaviour
{
    //boolean determining if the moniter is on
    bool on;

    //float controls planets and child moons rotation speed
    public float speed = 5;

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

        //if statement controlling behaviour when power is on
        if(on == true)
        {
            //by rotating the parent circle the child moons will orbit the planet
            transform.Rotate(0, 0, speed * Time.deltaTime);        
        }
    }
}
