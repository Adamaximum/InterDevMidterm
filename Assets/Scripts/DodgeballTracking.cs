using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeballTracking : MonoBehaviour
{
    public GameManager gm;

    public TrailRenderer trail;

    public SphereCollider dodgeballCollider;
    public BoxCollider dividerCollider;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        trail = GetComponent<TrailRenderer>();

        dodgeballCollider = GetComponent<SphereCollider>();
        dividerCollider = GameObject.Find("Divider").GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            if (gameObject.name == "Dodgeball (" + i + ")")
            {
                if (gameObject.transform.position.z < 0)
                {
                    gm.onSide[i] = true;
                }
                else
                {
                    gm.onSide[i] = false;
                }

                if (gm.lastHeldBy[i] == "None")
                {
                    trail.emitting = false;
                }
                else
                {
                    trail.emitting = true;
                }
            }
        }

        Physics.IgnoreCollision(dodgeballCollider, dividerCollider);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            for (int i = 0; i < 6; i++)
            {
                if (gameObject.name == "Dodgeball (" + i + ")")
                {
                    gm.lastHeldBy[i] = "None";
                }
            }
        }
    }
}
