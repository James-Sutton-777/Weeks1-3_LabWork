using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class OffScreen : MonoBehaviour
{
    //boolean determining if the moniter is on
    bool on;
    //create refrence to the spriteRenderer component which will be use the off screen sprite as input
    public SpriteRenderer screen;
    //animation curve
    public AnimationCurve curve;
    //range for t modifier
    [Range(0,1)]
    public float t;
    //rate at which alpha is modified
    float rate = 1;

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

        //if statement causing alpha to decrease when power is on
        if(on == true)
        {
            //t is modified by the rate multiplied by delta time
            t += (rate * Time.deltaTime);
        }
        
        //if statement causing alpha to increase when power is off
        if(on == false)
        {
            //t is modified by the rate * 3 to increase speed and multiplied by delta time
            t -= ((rate * 3) * Time.deltaTime);
        }

        //similar to changing position we first create a color varibale and modify its alpha before adding it back to the component value
        Color transparency = screen.color;
        transparency.a = Mathf.Lerp(0, 1, curve.Evaluate(t));
        screen.color = transparency;
    }
}
