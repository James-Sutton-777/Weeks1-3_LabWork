using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeFlasher : MonoBehaviour
{
    //boolean determining if the moniter is on
    bool on;
    //animation curve to control pulse effect
    public AnimationCurve pulseCurve;

    [Range(0, 1)]
    public float cycle;

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

        if (on == true)
        {
            cycle += Time.deltaTime;

            if(cycle > 1)
            {
                cycle = 0;
            }

            transform.localScale = Vector2.one * pulseCurve.Evaluate(cycle);
        }
    }
}
