using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int gameState;
    // 0 = Start
    // 1 = Game
    // 2 = Game Over

    public GameObject[] campers;

    public string[] lastHeldBy;
    public bool[] onSide;

    // Start is called before the first frame update
    void Start()
    {
        campers[0] = GameObject.Find("LittleKid");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
