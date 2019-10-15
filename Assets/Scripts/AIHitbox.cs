using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AIHitbox : MonoBehaviour
{
    public GameManager gm;

    public TextMeshProUGUI label;

    [Header ("Camper In/Out")]
    public bool camperOut;
    public float disappearTimer = 5;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        label = GameObject.Find("Feed").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (camperOut)
        {
            disappearTimer -= Time.deltaTime;
        }
        if (disappearTimer <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Dodgeball")
        {
            for (int i = 0; i < 6; i++)
            {
                if (gm.lastHeldBy[i] == "Player" && camperOut == false)
                {
                    if (gameObject.tag == "Body")
                    {
                        Debug.Log("Target is out!");
                        label.text = "Target is out!";
                        camperOut = true;
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
}
