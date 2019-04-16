using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour {

    private GameObject player;
    private AudioSource mySound;
    private Rigidbody2D rb2d;
    private float speed;
    private float timer = 5f;

	void Start () {
        player = GameObject.Find("robot");
        mySound = GetComponent<AudioSource>();
        speed = 5f;
        rb2d = GetComponent<Rigidbody2D>();
        
	}

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) Destroy(gameObject);

        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }

}
