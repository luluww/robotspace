using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingStar : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    private GameObject player;
    private Vector2 endPos;
    
    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("robot");
        endPos = Camera.main.ScreenToWorldPoint(new Vector2(-transform.position.x, transform.position.y));
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    void OnBecameInvisible()
    {
        Debug.Log("Invisible man");
        Destroy(gameObject);
    }

   

}
