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
        
    }

    //Deactivates current camera and set next camera on array
    private void CameraControl()
    {
        if (Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            cameras[lastCamera].SetActive(false);
            vCameras[lastCamera].SetActive(false);
            cameras[newCamera].SetActive(true);
            vCameras[newCamera].SetActive(true);
            lastCamera += 1;
            newCamera += 1;
            lastCamera = CameraArrayControl(lastCamera);
            newCamera = CameraArrayControl(newCamera);
        }
    }

    // Loops Array pointer to 0 position
    private int CameraArrayControl(int Array)
    {
        if (Array == camNumber)
        {
             Array = 0;
        }
        return Array;
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
