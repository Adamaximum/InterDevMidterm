using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody myRB;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            myRB.AddRelativeForce(Vector3.forward * 10);
        }
        if (Input.GetKey(KeyCode.S))
        {
            myRB.AddRelativeForce(Vector3.back * 10);
        }
        if (Input.GetKey(KeyCode.A))
        {
            myRB.AddRelativeForce(Vector3.left * 10);
        }
        if (Input.GetKey(KeyCode.D))
        {
            myRB.AddRelativeForce(Vector3.right * 10);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRB.AddRelativeForce(Vector3.up * 10 * 30);
        }
    }
}
