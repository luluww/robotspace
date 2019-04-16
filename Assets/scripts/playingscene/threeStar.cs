using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class threeStar : MonoBehaviour {

    public GameObject center;
    public float speed;

	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        OrbitAround();
	}

    void OrbitAround()
    {
        transform.RotateAround(center.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
