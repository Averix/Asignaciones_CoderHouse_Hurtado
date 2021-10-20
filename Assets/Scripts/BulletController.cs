using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //damage, speed and direction
    public float speed = 1.0f;
    public int damage = 50;
    public Vector3 bulletDirection = new Vector3 (0,0,1);
    //public for testing purposes
    public float positionMagnitude;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BulletMovement(bulletDirection);
        positionMagnitude = transform.position.sqrMagnitude;
        if (positionMagnitude > 400)
        {
            Destroy(gameObject);

        }
    }
    
    //bullet movement
    private void BulletMovement(Vector3 direction)
    {
        transform.Translate(speed * Time.deltaTime * direction);
    }
}
