using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject pipe;
    private float spawnRate ;
    private float timer = 0;
    private float heightOffset = 3f;
 int currentLevelIndex;
    void Start()
    {
    currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentLevelIndex == 1)
        {
            spawnRate = 2.5f;  
        }
     if (currentLevelIndex == 2)
        {
            spawnRate = 1.50f;  
        }
        spawnPipe();
    }

     
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }

    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
