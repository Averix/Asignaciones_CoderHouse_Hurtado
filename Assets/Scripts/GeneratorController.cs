using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    //bullet prefab array, 
    public GameObject[] bulletPrefab;


    //spawn frequency for bullets shot
    public float shotFrequency = 2.00f;

    //current bullet flag, bullet index and alive time
    private bool bulletAlive = false;
    private int bulletIndex = 0;
    private float shotTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShotControl();
    }

    void GeneratorControl()
    {
        //takes a shot if no bullet is present on the scene
        if (!bulletAlive)
        {
            //Random Index selection
            bulletIndex = Random.Range(0, bulletPrefab.Length);
            //Bullet creation. Bullet movement script operates by default
            Instantiate(bulletPrefab[bulletIndex], transform.position, bulletPrefab[bulletIndex].transform.rotation);
            //Set current bullet flag to true
            bulletAlive = true;
        }

        //as long as a bullet exists
        if (bulletAlive)
        {
            //starts shot alive timer
            shotTime += Time.deltaTime;

            //once user defined destroyTimer seconds have passed
            //the flag and timer are reset so another bullet can be shot
            if (shotTime >= shotFrequency)
            {
                shotTime = 0;
                bulletAlive = false;
            }

        }

    }
    void ShotControl()
    {
        //takes a shot if no bullet is present on the scene and left mouse click is pressed
        if (Input.GetKey(KeyCode.Mouse0) && !bulletAlive)
        {
            //Random Index selection
            bulletIndex = Random.Range(0, bulletPrefab.Length);
            //Bullet creation. Bullet movement script operates by default
            Instantiate(bulletPrefab[bulletIndex], transform.position, transform.rotation);
            //Set current bullet flag to true
            bulletAlive = true;
        }

        //as long as a bullet exists
        if (bulletAlive)
        {
            //starts shot alive timer
            shotTime += Time.deltaTime;

            //once user defined destroyTimer seconds have passed
            //the flag and timer are reset so another bullet can be shot
            if (shotTime >= shotFrequency)
            {
                shotTime = 0;
                bulletAlive = false;
            }

        }
    }
}
