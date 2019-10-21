using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
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
