using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatingBackground : MonoBehaviour {


    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

	// Use this for initialization
	void Start ()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x* 0.3f;
        Debug.Log(groundHorizontalLength);
	}

    
    void Update ()
    {
        if(transform.position.x<-groundHorizontalLength)
        {
            RepositionBackground();
        }

        
    }

    private void RepositionBackground()
    {
        Vector2 groundoffset = new Vector2(groundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundoffset;
    }
}
