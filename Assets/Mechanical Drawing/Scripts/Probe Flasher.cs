using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeFlasher : MonoBehaviour
{
    //boolean determining if the moniter is on
    bool on;
    //animation curve to control pulse effect
    public AnimationCurve pulseCurve;
   
    //create range for cycle modifier
    [Range(0, 1)]
    public float cycle;

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
           on =! on;
        }

        //if statement controlling behaviour when power is on
        if (on == true)
        {
            //Cycle is progressively increase by delta time
            cycle += Time.deltaTime;

            //if cycle surpasses 1 it resets to 0
            if(cycle > 1)
            {
                cycle = 0;
            }
            //modify scale of flasher using the curve with cycle variable as input multiplying Vector2.one to be compatible with transform
            transform.localScale = Vector2.one * pulseCurve.Evaluate(cycle);
        }
    }
}
