using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starArrayControl : MonoBehaviour {

    private GameObject player;

    private Vector2 player_pos;
    private Vector2 temp_pos;
    private Rigidbody2D rb2d;
    private Animator anim;
   

    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("robot");
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

        //move towards player
        Vector2 posDePlayer = player.transform.position;
        Vector2 myPos = transform.position;
        Vector2 force = posDePlayer - myPos;

        if(force.magnitude<3f)
        {
            if (posDePlayer.y > myPos.y && posDePlayer.x < myPos.x)
            {
                anim.SetTrigger("attackUp");
            }
            else if (posDePlayer.y > myPos.y && posDePlayer.x > myPos.x)
            {
                anim.SetTrigger("attackul");
            }
            else if (posDePlayer.y < myPos.y && posDePlayer.x < myPos.x)
            {
                anim.SetTrigger("attackBottom");
            }
            else if (posDePlayer.y < myPos.y && posDePlayer.x > myPos.x)
            {
                anim.SetTrigger("attackbr");
            }
        }
        else
        {
            anim.SetTrigger("backIdle");

            
            rb2d.AddForce(force);
           
        }

        

        

        //change array to attack player

    }
}
