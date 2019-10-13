using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeballTracking : MonoBehaviour
{
    public GameManager gm;

    public bool onSide;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < 0)
        {
            onSide = true;
        }
        else
        {
            onSide = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            gm.live[0] = false;
        }
    }
}
