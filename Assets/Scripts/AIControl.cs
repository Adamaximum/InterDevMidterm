using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour
{
    public GameManager gm;

    public GameObject dodgeball;

    public bool held;

    public float heldDistX = -0.9f;
    public float heldDistY = 0.3f;

    public int charge = 100;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

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

            gm.live[0] = true;

            if (Input.GetMouseButton(0) && charge < 700)
            {
                charge += 5;
            }

            if (Input.GetMouseButtonUp(0))
            {
                held = false;
                dodgeball.GetComponent<Rigidbody>().isKinematic = false;
                dodgeball.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * charge);
                dodgeball.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 100);
                charge = 100;
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
