using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMechanic : MonoBehaviour
{
    // Array para indicar las posiciones validas que puede tomar el objeto
    // y variable para recordar la posicion previa
    [SerializeField] private GameObject[] positions;
    private int currentPosition;
    private float counter = 0.00f;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = positions.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            counter += Time.deltaTime;
            if (counter >= 2.00f)
            {
                PositionRandomizer();
                counter = 0.00f;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            counter = 0.00f;
        }

    }

    // Method to iterate Object position from a given array of empty GameOPbjects
    private void PositionRandomizer()
    {
        // Get a random index from 0 to Array lenght -1
        int index = Random.Range(0, positions.Length);
        // If the index is different from teh current position index then change position and rotation
        if (index != currentPosition)
        {
            // Assign new position and rotation 
            transform.position = positions[index].transform.position;
            transform.rotation = positions[index].transform.rotation;
            // Register new current position index
            currentPosition = index;
        }
    }
}
