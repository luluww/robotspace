using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ariesControl : MonoBehaviour {

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject star4;
    public AudioClip sound_flying;

    private GameObject player;
    private Rigidbody2D rb2d;
    private float startTime;
    private float currentTime;
    private Animator anim;
    private AudioSource myAudio;
	void Start ()
    {
        player = GameObject.Find("robot");
        startTime = Time.time;
        myAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentTime = Time.time;

        if(currentTime-startTime>=0.5f) shootMyStar(star1);
        if (currentTime - startTime >= 1.5f) shootMyStar(star2);
        if (currentTime - startTime >= 2.5f) shootMyStar(star3);
        if (currentTime - startTime >= 3.5f) shootMyStar(star4);

    }

    void shootMyStar(GameObject star)
    {

        anim = star.GetComponent<Animator>();
        myAudio.PlayOneShot(sound_flying);
        rb2d = star.GetComponent<Rigidbody2D>();

        anim.SetTrigger("move");
        Vector2 playerPos = player.transform.position;
        Vector2 starPos = star.transform.position;
        Vector2 force = playerPos - starPos;

        if (starPos.x > playerPos.x)
            rb2d.AddForce(2f * force);
        else
            rb2d.AddForce(transform.right * 0.2f);

    }
}
