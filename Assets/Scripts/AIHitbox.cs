using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHitbox : MonoBehaviour
{
    //public GameObject body;
    //public GameObject head;

    // Start is called before the first frame update
    void Start()
    {
        //body = GetComponent<GameObject>();
        //head = GetComponentInChildren<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Dodgeball")
        {
            if (gameObject.tag == "Body")
            {
                Debug.Log("Target is out!");
            }
            if (gameObject.name == "Head")
            {
                Debug.Log("Headshot! You are out!");
            }
        }
    }
}
