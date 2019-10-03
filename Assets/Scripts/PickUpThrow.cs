using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Credit goes to Frank for most of this code.
public class PickUpThrow : MonoBehaviour
{
    public GameObject dodgeball;

    public bool held;

    public float heldDistX = -0.9f;
    public float heldDistY = 0.3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!held)
            {
                dodgeball.GetComponent<Rigidbody>().isKinematic = true;
                held = true;
            }
            else
            {
                dodgeball.GetComponent<Rigidbody>().isKinematic = false;
                held = false;
            }
        }

        if (held)
        {
            dodgeball.transform.position = gameObject.transform.position + new Vector3(heldDistX, heldDistY, 0);
            dodgeball.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            if (Input.GetMouseButtonDown(0))
            {
                held = false;
                dodgeball.GetComponent<Rigidbody>().isKinematic = false;
                dodgeball.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 500);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Dodgeball" && !held)
        {
            dodgeball = other.transform.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Dodgeball" && !held)
        {
            dodgeball = null;
        }
    }
}
