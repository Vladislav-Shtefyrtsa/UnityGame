using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public float speed = 12;
    float destroying;

    void Start()
    {
        destroying = -Camera.main.orthographicSize - transform.localScale.y;
    }

    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed,Space.Self);
        if(transform.position.y < destroying)
        {
            Destroy(gameObject);
        }
    }
}
