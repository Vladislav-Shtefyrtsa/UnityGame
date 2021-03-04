using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInstantiating : MonoBehaviour
{

    public GameObject coin;
    public float spawnTime;
    Vector2 cameraXY;

    void Start()
    {
        cameraXY = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    void Update()
    {
        if (Time.time > spawnTime)
        {
            spawnTime = Time.time + .5f;
            Vector2 spawnPosition = new Vector2(Random.Range(-cameraXY.x + (coin.transform.localScale.y / 2), cameraXY.x - (coin.transform.localScale.y / 2)), cameraXY.y + (coin.transform.localScale.y / 2));
            GameObject spawnedPrefab = (GameObject)Instantiate(coin, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
            spawnedPrefab.transform.parent = transform;
            spawnedPrefab.AddComponent<Falling>();
        }
    }
}