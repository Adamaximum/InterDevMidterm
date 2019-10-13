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

    public float pickUpTimer = 5;
    public int decisionTime;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        pickUpTimer -= Time.deltaTime;
        if (pickUpTimer <= 0)
        {
            pickUpTimer = 5;
            decisionTime = Random.Range(1, 5);
        }
        if (Mathf.RoundToInt(pickUpTimer) == decisionTime)
        {
            pickUpTimer = 0;
            if (!held)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (gm.onSide[i] == false)
                    {
                        dodgeball = GameObject.Find("Dodgeball (" + i + ")").transform.gameObject;
                    }
                }

                dodgeball.GetComponent<Rigidbody>().isKinematic = true;
                held = true;
                Debug.Log("Pick it up!");

                charge = Random.Range(100, 500);
            }
            else
            {
                held = false;
                Debug.Log("Throw it!");
                dodgeball.GetComponent<Rigidbody>().isKinematic = false;
                dodgeball.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * charge);
                dodgeball.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 100);
            }
        }

        if (held)
        {
            dodgeball.transform.position = gameObject.transform.position + new Vector3(heldDistX, heldDistY, 0);
            dodgeball.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            for (int i = 0; i < 6; i++)
            {
                if (dodgeball.name == "Dodgeball (" + i + ")")
                {
                    gm.live[i] = true;
                }
            }
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Dodgeball" && !held)
    //    {
    //        dodgeball = other.transform.gameObject;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Dodgeball" && !held)
    //    {
    //        dodgeball = null;
    //    }
    //}
}
