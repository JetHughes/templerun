using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class obstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject horizontalObstaclePrefab;
    public GameObject world;
    public float frequency;
    public float horizontalObstacleFrequency;
    public float initialDelay;
    private float delay;
    float startTime;
    private const float increaseTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        // SpawnObstacle();
        world = GameObject.FindWithTag("world");
        InvokeRepeating ("SpawnObstacle", frequency, delay);
        InvokeRepeating ("SpawnHorizontalObstacle", frequency, horizontalObstacleFrequency);
        startTime = Time.time;
        delay = initialDelay;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Math.Abs(Time.time - startTime) > 1 + frequency && delay > 0.5){
            startTime = Time.time;
            delay -= 0.2f;
            print("delay: " + delay);
            CancelInvoke("SpawnObstacle");
            InvokeRepeating ("SpawnObstacle", 0, delay);
        }
    }

    void SpawnObstacle()
    {
        float x = (float)((UnityEngine.Random.Range(0, 5)*2)-4f)*0.2f;

        Vector3 location = new Vector3(x, 2.0f, 20.0f);

        GameObject obstacle = Instantiate(obstaclePrefab, location, Quaternion.identity);
        obstacle.transform.SetParent(world.transform, true);
    }

    void SpawnHorizontalObstacle(){
        Vector3 location = new Vector3(0.0f, 1.5f, 20.0f);

        GameObject obstacle = Instantiate(horizontalObstaclePrefab, location, Quaternion.identity);
        obstacle.transform.SetParent(world.transform, true);
    }
}
