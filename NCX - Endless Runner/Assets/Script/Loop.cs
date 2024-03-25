using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    private void Start()
    {
        SpawnObstacle();
    }
    void Update()
    {
        transform.position -= new Vector3(0.05f, 0, 0);
        if(transform.position.x <= -40.0025f)
        {
            Instantiate(gameObject, new Vector3(120.01f, 0, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public GameObject obstaclePrefab;

    void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(55,58);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);

    }
}
