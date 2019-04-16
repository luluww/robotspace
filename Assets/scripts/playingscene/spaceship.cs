using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceship : MonoBehaviour {

    private Rigidbody2D rb2d;
    private Animator anim;

    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GameControl.instance.gameOver == true||GameControl.instance.withUFO==true)
        {
            rb2d.velocity = Vector2.zero;
        }
        else
            rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);

        if (GameControl.instance.withUFO == true)
        {
            Debug.Log("haha");
            anim.SetTrigger("fly");
        }
            

        float dist = (transform.position - Camera.main.transform.position).z;
        float bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        float top = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

        if (transform.position.y > top)
            transform.position = new Vector2(transform.position.x, top);
        else if (transform.position.y < bottom)
            transform.position = new Vector2(transform.position.x, bottom);
    }

}
