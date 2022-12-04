using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    // Connect from the player controller script
    private PlayerController playerControllerScript;
    // Declare a boundary
    private float leftBound = -15;
    // Start is called before the first frame update
    void Start()
    {
        // Find the player from the script
        playerControllerScript =
            GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       // If the game is over stop the background from moving
        if (playerControllerScript.gameOver == false) 
        {
            if (playerControllerScript.doubleSpeed)
            {
                transform.Translate(Vector3.left * Time.deltaTime * (speed * 2));
            }
            else
            { 
            // Move an object over time at a certain speed
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
        }
        // If the obstacle pass of the boundary, destroy
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}


