using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMove : MonoBehaviour
{
    Rigidbody myRB;
    Vector3 myInput;

    public float speed = 10f;

    public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        myInput = horizontal * transform.right;
        myInput += vertical * transform.forward;

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            myRB.AddForce(Vector3.up * 5, ForceMode.Impulse);
            grounded = false;
        }
    }

    private void FixedUpdate()
    {
        if (grounded)
        {
            myRB.velocity = myInput * speed;
        }
        else
        {
            myRB.velocity = new Vector3(myInput.x * speed, myRB.velocity.y, myInput.z * speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
