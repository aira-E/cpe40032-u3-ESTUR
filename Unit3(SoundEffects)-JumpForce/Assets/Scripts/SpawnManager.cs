using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    // Get access to the player controller script
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        // Find the player in the player controller script
        playerControllerScript =
            GameObject.Find("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {   
    }
    void SpawnObstacle()
    {
        // If the game is over stop instantiating obstacle prefabs
        if (playerControllerScript.gameOver == false) 
        {
            // DRY principle - Declare a range
            int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
            // Create clones of the obstacle prefabs at a certain position
            Instantiate(obstaclePrefab[obstacleIndex], spawnPos,
            obstaclePrefab[obstacleIndex].transform.rotation);
          }
    }
}
