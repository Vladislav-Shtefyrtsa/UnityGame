using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Moving2D : MonoBehaviour
{
    public float speed;
    float halfWidth;
    Vector3 startPos,currentPos;
    public Transform leftMarigne, rightMargine;



    void Start()
    {
        halfWidth = Camera.main.aspect * Camera.main.orthographicSize - ((rightMargine.position.x - leftMarigne.position.x)/2);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = Camera.main.ScreenToWorldPoint(touch.position) - transform.position;
                    break;

                case TouchPhase.Moved:
                    currentPos = Camera.main.ScreenToWorldPoint(touch.position) - startPos;
                    transform.position = new Vector3(currentPos.x,transform.position.y,transform.position.z);
                    break;
            }
        }
        if(transform.position.x > halfWidth)
        {
            transform.position = new Vector3(halfWidth,transform.position.y,transform.position.z);
        }
        if (transform.position.x < -halfWidth)
        {
            transform.position = new Vector3(-halfWidth, transform.position.y, transform.position.z);
        }
    }
}
