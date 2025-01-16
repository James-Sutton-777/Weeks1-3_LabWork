using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpaceInvader : MonoBehaviour
{
    float timerRate;
    float time;
    public float moveRate = 5;
    public float moveDistance = 1;
    public float marchDist = 1;
    float marchCount;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        timerRate = 1;
        marchCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += timerRate * Time.deltaTime;

        if (marchCount == marchDist)
        {
            Vector3 pos = transform.position;
            pos.y -= 1;
            transform.position = pos;
            marchCount = 0;
            moveDistance = moveDistance * -1;
        }
        else (time > moveRate)
        {
            Vector3 pos = transform.position;
            pos.x += moveDistance;
            transform.position = pos;
            marchCount += 1;
        }
    }
}
