using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotDragonControl : MonoBehaviour {

    
	void Start ()
    {
        transform.position = new Vector2(-10f, Random.Range(-5f, 5f));
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(GameControl.instance.withUFO==false)
        {
            transform.position = new Vector2(transform.position.x + 0.05f, transform.position.y);
        }


        //destroy the dragon when it's off screen
        if (transform.position.x>10f)
        {
            Destroy(gameObject);
        }
	}
}
