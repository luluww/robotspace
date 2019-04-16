using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starDragonControl : MonoBehaviour {

    private float startTime;
    private float currentTime;
    void Start ()
    {
        transform.position = new Vector2(-10f, Random.Range(-5f, 5f));
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector2(transform.position.x + 0.02f, transform.position.y);

        if (transform.position.x > 10f)
        {
            Destroy(gameObject);
        }

        currentTime = Time.time;
        if (currentTime - startTime >= 30f)
            Destroy(gameObject);
    }
}
