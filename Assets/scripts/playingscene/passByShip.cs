using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passByShip : MonoBehaviour {

    public float speed = 5.0f;
    public float turnSpeed = 100.0f;

    private Rigidbody2D rb2d;

    Collider2D col;

    void Start ()
    {
        col = transform.GetComponent<Collider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        transform.position += transform.right *speed* Time.deltaTime;

        //destroy the gameobject when it moves out of screen
        float dist = (transform.position - Camera.main.transform.position).z;
        float bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        float top = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
        if (transform.position.y > top || transform.position.y < bottom)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Vector3 pos_col = col.transform.position;
        Vector3 pos_target;
        speed = 0;
        //if col at left top side
        if (pos_col.y > transform.position.y)
        {
            pos_target = new Vector3(pos_col.x, pos_col.y - 5 * col.transform.localScale.y, 0);
            Debug.Log("top");
        }
        else
        {
            pos_target = new Vector3(pos_col.x, pos_col.y + 5 * col.transform.localScale.y, 0);
            Debug.Log("bottom");
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.position, transform.position - pos_target), Time.deltaTime);
        rb2d.AddForce((pos_target) * turnSpeed*Time.deltaTime);

        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        speed = 5f;
    }

    
}
