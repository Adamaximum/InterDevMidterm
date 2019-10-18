using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AIControl : MonoBehaviour
{
    public GameManager gm;
    public AIHitbox hitbox;
    public Transform playerTR;

    public TextMeshProUGUI feed;

    [Header ("AI Movement")]
    public bool reverse;
    public float movementSpeed;
    float movementInput;

    [Header ("Dodgeball Holding")]
    public GameObject dodgeball;

    public bool held;

    public float heldDistX = -0.9f;
    public float heldDistY = 0.3f;

    [Header ("Dodgeball Charge")]
    public int chargeRandMin = 100;
    public int chargeRandMax = 500;
    public int charge = 100;

    [Header ("Pickup/Throw Timer")]
    public float timerMax = 5;
    public float pickUpTimer;
    public int decisionTime;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        hitbox = GetComponent<AIHitbox>();
        playerTR = GameObject.Find("Player").GetComponent<Transform>();

        feed = GetComponentInChildren<TextMeshProUGUI>();
        feed.text = "";
    }

    void Update()
    {
        if (!hitbox.camperOut)
        {
            if (gm.gameState == 1)
            {
                AIPickUpThrow();
            }
            else
            {
                if (dodgeball != null)
                {
                    dodgeball.GetComponent<Rigidbody>().isKinematic = false;
                }
            }
            AIMovement();
        }
        else
        {
            if (dodgeball != null)
            {
                dodgeball.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    void AIPickUpThrow()
    {
        pickUpTimer -= Time.deltaTime;

        if (pickUpTimer <= 0)
        {
            pickUpTimer = timerMax;
            decisionTime = Random.Range(1, Mathf.RoundToInt(timerMax));
        }

        if (Mathf.RoundToInt(pickUpTimer) == decisionTime + 4 && held)
        {
            feed.text = ".";
        }
        else if (Mathf.RoundToInt(pickUpTimer) == decisionTime + 3 && held)
        {
            feed.text = "..";
        }
        else if (Mathf.RoundToInt(pickUpTimer) == decisionTime + 2 && held)
        {
            feed.text = "...";
        }
        else if (Mathf.RoundToInt(pickUpTimer) == decisionTime + 1 && held)
        {
            feed.text = "!";
        }
        else
        {
            feed.text = "";
        }

        if (Mathf.RoundToInt(pickUpTimer) == decisionTime)
        {
            pickUpTimer = 0;
            if (!held)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (gm.onSide[i] == false && gm.lastHeldBy[i] == "None")
                    {
                        dodgeball = GameObject.Find("Dodgeball (" + i + ")").transform.gameObject;

                        dodgeball.GetComponent<Rigidbody>().isKinematic = true;
                        held = true;
                        Debug.Log("Pick it up...");

                        charge = Random.Range(chargeRandMin, chargeRandMax);
                    }
                }
            }
            else
            {
                held = false;
                Debug.Log("Throw it!");
                dodgeball.GetComponent<Rigidbody>().isKinematic = false;
                dodgeball.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * charge);
                dodgeball.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 100);

                dodgeball = null;

                feed.text = "!";
            }
        }

        if (held)
        {
            dodgeball.transform.position = gameObject.transform.position + new Vector3(heldDistX, heldDistY, 0);
            //dodgeball.transform.eulerAngles = new Vector3(0, playerTR.localEulerAngles.y + 180, 0);
            dodgeball.transform.LookAt(playerTR);

            for (int i = 0; i < 6; i++)
            {
                if (dodgeball.name == "Dodgeball (" + i + ")")
                {
                    gm.lastHeldBy[i] = gameObject.name;
                }
            }
        }
    }

    void AIMovement()
    {
        if (gameObject.name == "MediumKid")
        {
            transform.position += new Vector3(0f, 0f, movementInput);

            if (transform.position.z >= 14)
            {
                reverse = true;
            }
            else if (transform.position.z <= 1)
            {
                reverse = false;
            }

            if (reverse)
            {
                movementInput = -movementSpeed;
            }
            else if (!reverse)
            {
                movementInput = movementSpeed;
            }
        }
        else if (gameObject.name == "BigKid")
        {
            transform.position += new Vector3(movementInput, 0f, 0f);

            if (transform.position.x >= 10)
            {
                reverse = true;
            }
            else if (transform.position.x <= -9.6f)
            {
                reverse = false;
            }

            if (reverse)
            {
                movementInput = -movementSpeed;
            }
            else
            {
                movementInput = movementSpeed;
            }
        }
    }
}
