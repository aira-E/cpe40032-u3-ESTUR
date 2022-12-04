using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        score = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            if (playerControllerScript.doubleSpeed)
            {
                scoreValue += 2;
            }
            else
            {
                scoreValue++; 
            }
            // Prompt the score on the debug log and on the creen
            Debug.Log("Score: " + scoreValue);
            score.text = "Score: " + scoreValue;
        }
    }
}



