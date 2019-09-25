using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMove : MonoBehaviour
{
    Rigidbody myRB;
    Vector3 myInput;

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
    }

    private void FixedUpdate()
    {
        myRB.velocity = myInput * 10f;
    }
}
