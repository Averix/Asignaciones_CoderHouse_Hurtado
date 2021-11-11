using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 10.0f;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Collider playerCollider;
    [SerializeField] private Rigidbody playerRB;
    private bool isSmall = false;
    private bool isJump = false;
    [SerializeField] private GameObject weapon;
    //private float jumpTime = 0.00f;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator.SetBool("Idle", true);
        playerRB = GetComponent<Rigidbody>();
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
            if (Input.GetAxis("Vertical") > 0)
            {
                playerAnimator.SetBool("Idle", false);
                playerAnimator.SetBool("Run", true);
                playerAnimator.SetBool("Back", false);
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                playerAnimator.SetBool("Idle", false);
                playerAnimator.SetBool("Run", false);
                playerAnimator.SetBool("Back", true);
            }
        }
        else
        {
            playerAnimator.SetBool("Back", false);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Idle", true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isJump == false)
        {
            isJump = true;
            playerAnimator.SetBool("Jump", true);
            playerRB.AddForce(Vector3.up * 10f);
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
        if (collision.gameObject.tag == "Ground" && isJump == true)
        {
            isJump = false;
            playerAnimator.SetBool("Jump", false);
        }
        if (collision.gameObject.tag == "Weapon")
        {
            weapon.SetActive(true);
        }
        
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
