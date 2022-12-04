using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        // Get the size of the box collider in x axis and devided by 2
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Reset our background from the first position
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
