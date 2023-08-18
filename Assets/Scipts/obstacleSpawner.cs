using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        // SpawnObstacle();
        InvokeRepeating ("SpawnObstacle", 0.5f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        // SpawnObstacle();
    }

    void SpawnObstacle()
    {
        float x = Random.Range(-3, 3);

        Vector3 location = new Vector3(x, 0.5f, 20.0f);

        Instantiate(obstaclePrefab, location, Quaternion.identity);
    }
}
