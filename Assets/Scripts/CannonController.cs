using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementControl();
    }

    void MovementControl()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // rotates CCW
            transform.Rotate(0, -Time.deltaTime * 180.0f, 0, Space.Self);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // rotates CW
            transform.Rotate(0, Time.deltaTime * 180.0f, 0, Space.Self);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(10.0f * Time.deltaTime * Vector3.forward, Space.Self);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(10.0f * Time.deltaTime * Vector3.back, Space.Self);
        }
    }
}
