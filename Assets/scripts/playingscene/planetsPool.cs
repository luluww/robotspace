using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetsPool : MonoBehaviour {

    public int planetsPoolSize = 11;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;
    public GameObject prefab6;
    public GameObject prefab7;
    public GameObject prefab8;
    public GameObject prefab9;
    public GameObject prefab10;
    public GameObject prefab11;

    private float spawnRate;
    public float planetMin = -6f;
    public float planetMax = 6f;

    private GameObject[] planets;
    private Vector2 poolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentPlanet = 0;


    void Start ()
    {
        planets = new GameObject[planetsPoolSize];
        planets[0]= (GameObject)Instantiate(prefab1, poolPosition, Quaternion.identity);
        planets[1] = (GameObject)Instantiate(prefab2, poolPosition, Quaternion.identity);
        planets[2] = (GameObject)Instantiate(prefab3, poolPosition, Quaternion.identity);
        planets[3] = (GameObject)Instantiate(prefab4, poolPosition, Quaternion.identity);
        planets[4] = (GameObject)Instantiate(prefab5, poolPosition, Quaternion.identity);
        planets[5] = (GameObject)Instantiate(prefab6, poolPosition, Quaternion.identity);
        planets[6] = (GameObject)Instantiate(prefab7, poolPosition, Quaternion.identity);
        planets[7] = (GameObject)Instantiate(prefab8, poolPosition, Quaternion.identity);
        planets[8] = (GameObject)Instantiate(prefab9, poolPosition, Quaternion.identity);
        planets[9] = (GameObject)Instantiate(prefab10, poolPosition, Quaternion.identity);
        planets[10] = (GameObject)Instantiate(prefab11, poolPosition, Quaternion.identity);

        
    }
	
	// Update is called once per frame
	void Update ()
    {
        timeSinceLastSpawned += Time.deltaTime;
        spawnRate = Random.Range(6f, 14f);

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(planetMin, planetMax);
            planets[currentPlanet].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentPlanet++;

            if (currentPlanet >= planetsPoolSize)
                currentPlanet = 0;
        }
    }
}
