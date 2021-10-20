using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    //bullet prefab array, 
    public GameObject[] bulletPrefab;
    
    //current bullet flag, bullet index and alive time
    //public only for testing purposes
    public bool bulletAlive = false;
    public int bulletIndex = 0;
    public float shotTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GeneratorControl();
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

            //once 5 seconds have passed the flag and timer are reset so another bullet can be shot
            if (shotTime >= 5.0f)
            {
                shotTime = 0;
                bulletAlive = false;
            }

        }

    }

}
