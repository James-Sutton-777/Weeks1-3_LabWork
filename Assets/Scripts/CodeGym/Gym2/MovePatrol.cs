using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePatrol : MonoBehaviour
{
    [Range(0, 1)]
    public float t;
    public float speed;
    int i = 0;
    public AnimationCurve curveA;
    public Transform start;
    public Transform destination;
    public GameObject prefab;
    public List<GameObject> waypoint;

    // Start is called before the first frame update
    void Start()
    {
        //waypoint = new List<GameObject>();
        //can be called in class ^
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        {
            if ((destination == null) || (start == null))
            {
                if (waypoint.Count > 1)
                {
                    destination = waypoint[1].transform;
                    start = waypoint[0].transform;
                }
            }
            else
            {
                transform.position = Vector2.Lerp(start.position, destination.position, curveA.Evaluate(t) * speed);
                t += Time.deltaTime;
                if (t >= 1)
                {
                    t = 0;
                    i++;
                    destination = waypoint[1].transform;
                    start = waypoint[0].transform;
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject thing = Instantiate(prefab);
            thing.transform.position = mouse;
            waypoint.Add(thing);
            if (waypoint.Count > 3)
            {
                GameObject dead = waypoint[0];
                waypoint.Remove(dead);
                Destroy(dead);
            }
        }
    }
}
