using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingBg : MonoBehaviour {

    private Rigidbody2D rb2d;
    private float speed = 0.5f;
    private float theTime;
    private int n;

	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        theTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (Time.time>=theTime+5f)
        {
            n = Random.Range(1, 3);
            theTime = Time.time;
        }

        switch(n)
        {
            case 1:
                moveUp();
                break;
            case 2:
                moveForward();
                break;
        }

       
	}

    void moveUp()
    {
        if(transform.position.y>=16f)
        {
            rb2d.velocity = new Vector2(0, -speed);
        }
        else if(transform.position.y<=-16f)
        {
            rb2d.velocity = new Vector2(0, speed);
        }
    }

    void moveForward()
    {
        if (transform.position.x <= -28f)
        {
            rb2d.velocity = new Vector2(speed, 0);
        }
        else if(transform.position.x>=28f)
        {
            rb2d.velocity = new Vector2(-speed, 0);
        }
        
    }
}
