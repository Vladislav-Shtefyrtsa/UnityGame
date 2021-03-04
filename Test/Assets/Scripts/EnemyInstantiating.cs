using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiating : MonoBehaviour
{

    public GameObject enemy;
    public float spawnTime;
    Vector2 cameraXY;

    void Start()
    {
        cameraXY = new Vector2(Camera.main.aspect * Camera.main.orthographicSize,Camera.main.orthographicSize);
    }

    void Update()
    {
        if(Time.time > spawnTime)
        {
            spawnTime = Time.time + .5f;
            float randomScale = Random.Range(0.5f, 3f);
            float scaleHypothenus = Mathf.Sqrt(randomScale*randomScale + randomScale*randomScale);
            Vector2 spawnPosition = new Vector2(Random.Range(-cameraXY.x + (scaleHypothenus/ 2), cameraXY.x - (scaleHypothenus / 2)),cameraXY.y  + (scaleHypothenus/2));
            GameObject spawnedPrefab = (GameObject)Instantiate(enemy,spawnPosition,Quaternion.Euler(new Vector3(0,0,Random.Range(-45,45))));
            spawnedPrefab.transform.localScale = new Vector3(randomScale,randomScale,randomScale);
            spawnedPrefab.transform.parent = transform;
            spawnedPrefab.AddComponent<Falling>();
        }
    }
}
