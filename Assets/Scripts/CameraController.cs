using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject[] cameras;
    [SerializeField] private GameObject[] vCameras;
    private int camNumber;
    private int lastCamera;
    private int newCamera;
    // Start is called before the first frame update
    void Start()
    {
        CamCheck();
        lastCamera = 0;
        newCamera = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CameraControl();
        CameraArrayControl();
    }

    void CameraControl()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            cameras[lastCamera].SetActive(false);
            vCameras[lastCamera].SetActive(false);
            cameras[newCamera].SetActive(true);
            vCameras[newCamera].SetActive(true);
            lastCamera += 1;
            newCamera += 1;
        }
    }

    void CameraArrayControl()
    {
        if (newCamera == camNumber)
        {
            newCamera = 0;
        }
        if (lastCamera == camNumber)
        {
            lastCamera = 0;
        }
    }

    //verifies the available cameras
    void CamCheck()
    {
        //save the total amount of cameras
        camNumber = cameras.Length;
        //disables all cameras
        for (int i = 0; i < camNumber; i++)
        {
            cameras[i].SetActive(false);
            vCameras[i].SetActive(false);
        }
        //enables first camera of array
        cameras[0].SetActive(true);
        vCameras[0].SetActive(true);
    }
}
