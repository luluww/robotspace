using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightShipControl : MonoBehaviour {

    public AudioClip sound_explosion;
    public AudioClip sound_disappear;
    public GameObject prefab_bullet;

    private AudioSource mySound;
    private GameObject player;
    private Rigidbody2D rb2d;
    private Animator anim;
    private float speed;
    private float period;
    private float timeSinceLastSpawned;
    private float spawnRate;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("robot");
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mySound = GetComponent<AudioSource>();
        speed = 5f;
        period = 0.5f;
        spawnRate=2f;
        transform.position = new Vector2(-15f, 0f);
        rb2d.velocity = new Vector2(-GameControl.instance.scrollSpeed, 0);
        Invoke("slowDown", 6);
        Invoke("disappear", 30);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 chasing = new Vector3(transform.position.x, player.transform.position.y, 0);
        rb2d.AddForce((chasing - transform.position) * speed * Time.deltaTime);

        timeSinceLastSpawned += Time.deltaTime;
        
        Vector3 offset = new Vector3(1.5f, 0, 0);
        
        if(timeSinceLastSpawned >= spawnRate)
        {
            Instantiate(prefab_bullet, transform.position + offset, transform.rotation);
            timeSinceLastSpawned = 0;
        }
            

    }

    void slowDown()
    {
        rb2d.velocity = Vector2.zero;
    }

    void disappear()
    {
        anim.SetTrigger("flash");
        mySound.PlayOneShot(sound_disappear);
        Destroy(gameObject, 1);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag!="bullet")
    //    {
    //        mySound.PlayOneShot(sound_explosion);
    //        anim.SetTrigger("exp");
    //        Destroy(gameObject, sound_explosion.length / 5);
    //    }

        
    //}
}
