using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Credit goes to Frank for most of this code.
public class PickUpThrow : MonoBehaviour
{
    public GameManager gm;

    [Header ("Dodgeball Holding")]
    public GameObject dodgeball;

    public bool held;

    public float heldDistX = -0.9f;
    public float heldDistY = 0.3f;

    [Header("Dodgeball Charge")]
    public int chargeMin = 100;
    public int chargeMax = 1500;
    public int charge = 100;

    public TextMeshProUGUI throwPow;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        throwPow = GameObject.Find("ThrowPower").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (gm.gameState == 1)
        {
            PickUpThrowAction();
        }
    }

    void PickUpThrowAction()
    {
        throwPow.text = "Throw Power: " + charge;

        if (Input.GetKeyDown(KeyCode.E) && dodgeball != null)
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

            for (int i = 0; i < 6; i++)
            {
                if (dodgeball.name == "Dodgeball (" + i + ")")
                {
                    gm.lastHeldBy[i] = "Player";
                }
            }

            if (Input.GetMouseButton(0) && charge < chargeMax)
            {
                charge += 5;
            }

            if (Input.GetMouseButtonUp(0))
            {
                held = false;
                dodgeball.GetComponent<Rigidbody>().isKinematic = false;
                dodgeball.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * charge);
                dodgeball.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 100);
                charge = chargeMin;
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
