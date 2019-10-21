using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHitbox : MonoBehaviour
{
    public GameManager gm;

    public TextMeshProUGUI label;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        label = GameObject.Find("Feed").GetComponent<TextMeshProUGUI>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < gm.lastHeldBy.Length; i++)
        {
            if (collision.gameObject.name == "Dodgeball (" + i + ")")
            {
                if (gm.lastHeldBy[i] == "BigKid" || gm.lastHeldBy[i] == "MediumKid" || gm.lastHeldBy[i] == "LittleKid")
                {
                    if (gameObject.tag == "Body")
                    {
                        gm.gameState = 2;
                        label.text = "Clean hit! You are out!";
                    }
                    if (gameObject.tag == "Head")
                    {
                        //Will add in headshot code for player later
                    }
                }
            }
        }
    }
}
