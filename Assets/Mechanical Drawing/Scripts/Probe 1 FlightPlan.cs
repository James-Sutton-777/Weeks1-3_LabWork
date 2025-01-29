using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Probe1FlightPlan: MonoBehaviour
{
    //boolean determining if the moniter is on
    bool on;
    //boolean determining if the probe has been launched
    bool launch;
    //create animation curve to modify X movement behaviour
    public AnimationCurve horiCurve;
    //create animation curve to mofify Y movement behaviour
    public AnimationCurve vertCurve;
    //create animation curve to mofify orientation behaviour
    public AnimationCurve rotCurve;

    //create range for dist modifier 0 being launch 1 being at destination
    [Range(0, 1)]
    public float dist;

    //float controls speed at which distance is covered aka rate if change
    float speed = 0.2f;

    //floats for launch point and destination positions
    //seperating x and y axis to fine tune probe behaviour
    public float launchY;
    public float destinationY;
    public float launchX;
    public float destinationX;
    //initial and final probe orientation
    public float initial;
    public float final;
    // Start is called before the first frame update
    void Start()
    {
       on = false;
        launch = false;

    }

    // Update is called once per frame
    void Update()
    {
        //if statement determining when the power has been turned on
        if (Input.GetKeyDown(KeyCode.Space))
        {
           on =! on;
        }

        if(on == true)
        {
            Vector3 posH = transform.position;
            posH.x = Mathf.Lerp(launchX, destinationX ,horiCurve.Evaluate(dist));
            transform.position = posH;

            Vector3 posV = transform.position;
            posV.y = Mathf.Lerp(launchY, destinationY, vertCurve.Evaluate(dist));
            transform.position = posV;

            Vector3 rot = transform.eulerAngles;
            rot.z = Mathf.Lerp(initial, final, rotCurve.Evaluate(dist));
            transform.eulerAngles = rot;

            if (Input.GetMouseButtonDown(0))
            {
                launch = true;
            }

            if(launch == true)
            {
                //dist is modified by speed with is multiplied by delta time to maintain consistency
                dist += speed * Time.deltaTime;
            }
        }
        
        if(on == false)
        {
            Vector3 origin = transform.position;
            origin.x = 1;
            origin.y = -6;
            transform.position = origin;

            Vector3 rot = transform.eulerAngles;
            rot.z = initial;
            transform.eulerAngles = rot;

            dist = 0;

            launch = false;
        }
    }
}
