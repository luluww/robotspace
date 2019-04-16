using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPool : MonoBehaviour {

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;

    private GameObject[] weapons;
    private Vector2 weapon1Pos;
    private Vector2  weapon2Pos;
    private Vector2 weapon3Pos;
    private Vector2 weapon45Pos;
    private float addWeaponInterval=10f;
    private float theTime;
        
    
    void Start ()
    {
        weapons = new GameObject[5];
        weapon1Pos = new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 5f));
        weapon2Pos = new Vector2(-10f, Random.Range(-5f, 5f));
        weapon3Pos = new Vector2(9f, 0f);
        weapon45Pos = new Vector2(-15f, 0f);
        theTime = Time.time;

    }




    // Update is called once per frame

    private void Update()
    {
        int n;

        if(GameControl.instance.gameOver==false)
        {
            if (Time.time >= theTime + 20f)
            {
                n = Random.Range(1, 6);
                switch (n)
                {
                    case 1:
                        loadWeapon1();
                        break;
                    case 2:
                        loadWeapon2();
                        break;
                    case 3:
                        loadWeapon3();
                        break;
                    case 4:
                        loadWeapon4();
                        break;
                    case 5:
                        loadWeapon5();
                        break;
                }
                theTime = Time.time;
            }
        }

        
    }



    void loadWeapon1()
    {
        weapons[0] = (GameObject)Instantiate(prefab1, weapon1Pos, Quaternion.identity);
    }

    void loadWeapon2()
    {
        weapons[1] = (GameObject)Instantiate(prefab2, weapon2Pos, Quaternion.identity);
    }

    void loadWeapon3()
    {
        weapons[2] = (GameObject)Instantiate(prefab3, weapon3Pos, Quaternion.identity);
    }

    void loadWeapon4()
    {
        weapons[3] = (GameObject)Instantiate(prefab4, weapon45Pos, Quaternion.identity);
    }

    void loadWeapon5()
    {
        weapons[4] = (GameObject)Instantiate(prefab5, weapon45Pos, Quaternion.identity);
    }
}
