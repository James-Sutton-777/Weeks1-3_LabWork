using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePatrol : MonoBehaviour
{
    [Range(0, 1)]
    public float t;
    public float speed;
    public AnimationCurve curveA;
    public Transform start;
    public Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(start.position, destination.position, curveA.Evaluate(t));
        t += speed * Time.deltaTime;
    }
}
