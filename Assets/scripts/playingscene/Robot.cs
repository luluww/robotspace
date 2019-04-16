using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {

    public float upForce = 200f;
    public AudioClip sound_explosion;
    public AudioClip sound_button_click;
    public AudioClip sound_getStar;
    //public AudioClip sound_button_click2;
    //public GameObject robot_pos_train;
    //public Rigidbody2D rb_train;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    private AudioSource myAudio;
    

    private void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start ()
    {
        
        anim = GetComponent<Animator>();
        myAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float dist = (transform.position - Camera.main.transform.position).z;
        float bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        float top = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
        
        if (transform.position.y > top)
            transform.position = new Vector2(transform.position.x, top);
        else if (transform.position.y < bottom)
            transform.position = new Vector2(transform.position.x, bottom);
    }

    public void robotFly()
    {

        if (GameControl.instance.gameOver==false)
        {

            //myAudio.PlayOneShot(sound_button_click2);
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0,upForce));

            if(GameControl.instance.withUFO==false)
                anim.SetTrigger("fly");
        
        }
       
    }

    public void robotBack()
    {
        if(GameControl.instance.gameOver==false)
        {
            //myAudio.PlayOneShot(sound_button_click2);

            if (GameControl.instance.withUFO == false)
            {
                anim.SetTrigger("sitDragon");
            }
                
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(-upForce, 0));

            anim.SetTrigger("back");

        }
    }

    public void robotJump()
    {
        if(GameControl.instance.gameOver==false)
        {
            myAudio.PlayOneShot(sound_button_click);
            transform.Find("robotDragon(Clone)").transform.parent=null;
                       
            GameControl.instance.withUFO = false;

            GameControl.instance.baseSpeed = GameControl.instance.baseSpeed/2;
            rb2d.freezeRotation = false;
            rb2d.AddForce(new Vector2(0, upForce));
            anim.SetTrigger("back");
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag=="dragon")
        {
            anim.SetTrigger("sitDragon");
            Vector2 pos = collision.transform.Find("pos").transform.position;
            transform.position = pos;
            GameControl.instance.withUFO = true;
            collision.transform.parent = transform;
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            rb2d.freezeRotation = true;
            GameControl.instance.baseSpeed = GameControl.instance.baseSpeed * 2;

        }





        //if (collision.gameObject.tag == "train")
        //{
        //    anim.SetTrigger("sitInUFO");
        //    transform.position = robot_pos_train.transform.position;
        //    GameControl.instance.withUFO = true;
        //    rb_train.transform.parent = transform;
        //    rb_train.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        //    rb2d.freezeRotation = true;
        //    GameControl.instance.takeSpaceship();
        
        //}

        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag!="train")
        {
            //if(GameControl.instance.withUFO==true&&collision.gameObject.tag=="star")
            //{
            //    collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            //    GameControl.instance.robotScored();
            //    myAudio.PlayOneShot(sound_getStar);
            //    Destroy(collision.gameObject);
            //    return;
            //}

            isDead = true;
            if (GameControl.instance.withUFO)
                anim.SetTrigger("sitTodie");
            else
                anim.SetTrigger("die");
            GameControl.instance.robotDie();
            myAudio.PlayOneShot(sound_explosion);
            Destroy(gameObject, sound_explosion.length);
        }
    }
}
