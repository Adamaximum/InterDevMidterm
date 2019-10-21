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

            label.text = "";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < gm.lastHeldBy.Length; i++)
        {
            if (collision.gameObject.name == "Dodgeball (" + i + ")")
            {
                if (gm.lastHeldBy[i] == "Player" && camperOut == false && gm.gameState == 1)
                {
                    if (gameObject.tag == "Body")
                    {
                        Debug.Log("Camper is out!");
                        label.text = "Camper is out!";
                        camperOut = true;
                        gm.campersLeft--;
                    }
                    if (gameObject.tag == "Head")
                    {
                        Debug.Log("Headshot! You are out!");
                        label.text = "Headshot! You are out!";

                        gm.gameState = 2;
                    }
                }
            }
        }
    }
}
