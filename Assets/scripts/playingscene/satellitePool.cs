using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class satellitePool : MonoBehaviour {

    public int satellitePoolSize = 7;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;
    public GameObject prefab6;
    public GameObject prefab7;
    public float spawnRate;
    public float satelliteMin=-8f;
    public float satelliteMax=8f;

    private GameObject[] satellites;
    private Vector2 poolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentSatellite = 0;

	void Start ()
    {
        satellites = new GameObject[satellitePoolSize];
        satellites[0] = (GameObject)Instantiate(prefab1, poolPosition, Quaternion.identity);
        satellites[1] = (GameObject)Instantiate(prefab2, poolPosition, Quaternion.identity);
        satellites[2] = (GameObject)Instantiate(prefab3, poolPosition, Quaternion.identity);
        satellites[3] = (GameObject)Instantiate(prefab4, poolPosition, Quaternion.identity);
        satellites[4] = (GameObject)Instantiate(prefab5, poolPosition, Quaternion.identity);
        satellites[5] = (GameObject)Instantiate(prefab6, poolPosition, Quaternion.identity);
        satellites[6] = (GameObject)Instantiate(prefab7, poolPosition, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update ()
    {
        timeSinceLastSpawned += Time.deltaTime;
        spawnRate = Random.Range(6f, 14f);

        if (GameControl.instance.gameOver==false&&timeSinceLastSpawned>=spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(satelliteMin, satelliteMax);
            satellites[currentSatellite].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentSatellite++;

            if (currentSatellite >= satellitePoolSize)
                currentSatellite = 0;
        }
	}
}
