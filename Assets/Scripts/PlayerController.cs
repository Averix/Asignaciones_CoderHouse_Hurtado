using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 10.0f;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Collider playerCollider;
    private bool isSmall = false;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator.SetBool("Idle", true);
    }

    // Update is called once per frame
    void Update()
    {
        // MovementControl();
        MovementControl2();
        
    }
    private void FixedUpdate()
    {
        
    }

    // Simplified movement control
    void MovementControl2()
    {
        transform.Rotate(0, Time.deltaTime * 180.0f * Input.GetAxis ("Horizontal"), 0, Space.Self);
        transform.Translate(playerSpeed * Time.deltaTime * Input.GetAxis("Vertical") * Vector3.forward , Space.Self);
        if(Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical") != 0)
        {
            playerAnimator.SetBool("Idle", false);
            playerAnimator.SetBool("Run", true);
        }
        else
        {
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Idle", true);
        }
    }

    void SizeChange()
    {
        if(isSmall == false)
        {
            transform.localScale = transform.localScale * 0.7f;
            isSmall = true;
        }
        else
        {
            transform.localScale = transform.localScale / 0.7f;
            isSmall = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        SizeChange();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
    }
    /*  void MovementControl()
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
      }*/
}
