using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AIHitbox : MonoBehaviour
{
    public GameManager gm;

    public TextMeshProUGUI label;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        label = GameObject.Find("Feed").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Dodgeball")
        {
            if (gm.live[0])
            {
                if (gameObject.tag == "Body")
                {
                    Debug.Log("Target is out!");
                    label.text = "Target is out!";
                }
                if (gameObject.tag == "Head")
                {
                    Debug.Log("Headshot! You are out!");
                    label.text = "Headshot! You are out!";
                }
            }
        }
    }
}
