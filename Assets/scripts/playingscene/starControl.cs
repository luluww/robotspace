using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starControl : MonoBehaviour {

    //public GameObject player;

    private Rigidbody2D rb2d;


	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //contain the star inside the screen

        float dist = (transform.position - Camera.main.transform.position).z;
        float bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        float top = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
        float right = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, dist)).x;
        float left = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).x;

        if (transform.position.y > top)
            transform.position = new Vector2(transform.position.x, bottom);
        else if (transform.position.y < bottom)
            transform.position = new Vector2(transform.position.x, top);
        else if (transform.position.x < left)
            transform.position = new Vector2(right, transform.position.y);
        else if (transform.position.x > right)
            transform.position = new Vector2(left, transform.position.y);
        

        //if robot without UFO, track and kill robot
        
    }
}
