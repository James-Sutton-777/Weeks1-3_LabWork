using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y += speed * Time.deltaTime;

        Vector2 squareInScreenSpace = Camera.main.WorldToScreenPoint(pos);

        if (squareInScreenSpace.y < 0)
        {
            Vector3 fixedPos = new Vector3(0, 0, 0);
            pos.y = Camera.main.ScreenToWorldPoint(fixedPos).y;
            speed = speed * -1;
        }

        if (squareInScreenSpace.y > Screen.height)
        {
            Vector3 fixedPos = new Vector3(0, Screen.height, 0);
            pos.y = Camera.main.ScreenToWorldPoint(fixedPos).y;
            speed = speed * -1;
        }

        transform.position = pos;
    }
}
