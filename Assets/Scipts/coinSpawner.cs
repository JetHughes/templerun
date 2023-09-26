using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject world;
    public float frequency;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        // SpawnObstacle();
        world = GameObject.FindWithTag("world");
        InvokeRepeating ("SpawnCoin", frequency, delay);
    }

    // Update is called once per frame
    void Update()
    {
        // SpawnObstacle();
    }

    void SpawnCoin()
    {
        float x = (float)((Random.Range(0, 5)*2)-4f)*0.2f;

        Vector3 location = new Vector3(x, 2.0f, 20.0f);

        GameObject obstacle = Instantiate(coinPrefab, location, Quaternion.identity);
        obstacle.transform.SetParent(world.transform, true);
    }
}
