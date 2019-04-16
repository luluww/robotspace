using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrierPool : MonoBehaviour {

    public GameObject prefab;
    private float spawnRate;
    private Vector2 poolPosition;
    private float timeSinceLastSpawned;
    private GameObject carrier;
    // Use this for initialization
    void Start ()
    {
		
    }
	
	// Update is called once per frame
	void Update ()
    {
        timeSinceLastSpawned += Time.deltaTime;
        spawnRate = Random.Range(6f, 14f);

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            poolPosition = new Vector2(-10f, Random.Range(-6f, 6f));
            carrier = (GameObject)Instantiate(prefab, poolPosition, Quaternion.identity);
            timeSinceLastSpawned = 0;
                       
        }
    }
}
