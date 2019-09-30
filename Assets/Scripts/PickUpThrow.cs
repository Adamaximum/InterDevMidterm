using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpThrow : MonoBehaviour
{
    public GameObject dodgeball;
    public Rigidbody dodgeballRB;

    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dodgeball, new Vector3(transform.position.x,transform.position.y,transform.position.z), Quaternion.identity);
            dodgeballRB.AddForce(Vector3.forward * 1000);
        }
    }
}
