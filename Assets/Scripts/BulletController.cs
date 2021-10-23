using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //damage, speed and direction
    public float speed = 1.0f;
    public int damage = 50;
    public Vector3 bulletDirection = new Vector3(0, 0, 1);
    public float destroyTimer = 2.00f;

    //magnitude for distance destruction of bullet
    //local timer for time to destory buillet
    //resizae flag to allow only one resize of bullet
    private float remainingDestroyTimer;
    private float positionMagnitude;
    private bool resizeFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        //sends destroy timer to private variable
        remainingDestroyTimer = destroyTimer;
    }

    // Update is called once per frame
    void Update()
    {
        BulletMovement(bulletDirection);
        TimerDestroy();
        DoubleSized();
    }

    //bullet movement
    private void BulletMovement(Vector3 direction)
    {
        transform.Translate(speed * Time.deltaTime * direction);
    }

    private void DistanceDestroy()
    {
        positionMagnitude = transform.position.sqrMagnitude;
        if (positionMagnitude > 400)
        {
            Destroy(gameObject);
        }
    }
    private void TimerDestroy()
    {
        remainingDestroyTimer -= Time.deltaTime;
        if (remainingDestroyTimer <= 0.00f)
        {
            Destroy(gameObject);
        }
    }
    private void DoubleSized()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&!resizeFlag)
        {
            transform.localScale = (transform.localScale * 2);
            resizeFlag = true;
        }
    }
}
