using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonPool : MonoBehaviour {

    public GameObject prefab;

    private Vector2 pos;
    private GameObject dragon;
    private float startTime;
    private float currentTime;

	// Use this for initialization
	void Start ()
    {
        pos = new Vector2(-15f, 25f);
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentTime = Time.time;

        if(currentTime>=startTime+60)
        {
            dragon=(GameObject)Instantiate(prefab, pos, Quaternion.identity);
            startTime = Time.time;
        }
	}
}
