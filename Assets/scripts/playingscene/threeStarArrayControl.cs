using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class threeStarArrayControl : MonoBehaviour {

    private GameObject player;

    private Rigidbody2D rb2d;
    private Animator anim;
    private float startTime;
    private float currentTime;

	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("robot");
        startTime = Time.time;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 posDePlayer = player.transform.position;
        Vector2 myPos = transform.position;
        Vector2 force = posDePlayer - myPos;

        if(force.magnitude<5f)
        {
            anim.SetTrigger("attack");
        }
        else
        {
            anim.SetTrigger("idle");
        }

        rb2d.AddForce(1*force);

        currentTime = Time.time;

        if (currentTime - startTime >= 20f)
            Destroy(gameObject);

    }
}
