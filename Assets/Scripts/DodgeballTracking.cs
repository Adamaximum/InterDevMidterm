using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeballTracking : MonoBehaviour
{
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            }
        }
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
