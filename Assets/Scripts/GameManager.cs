using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header ("Game Management")]
    public int gameState;
    // 0 = Start
    // 1 = Game
    // 2 = Game Over

    public Canvas IntroUI;
    public TextMeshProUGUI title;
    public TextMeshProUGUI subtitle;

    public Canvas PlayerUI;
    public TextMeshProUGUI campersRemaining;
    public int campersLeft;

    [Header ("Dodgeball Stats")]
    public string[] lastHeldBy;
    public bool[] onSide;

    // Start is called before the first frame update
    void Start()
    {
        IntroUI = GameObject.Find("IntroUI").GetComponent<Canvas>();
        title = GameObject.Find("Title").GetComponent<TextMeshProUGUI>();
        subtitle = GameObject.Find("Subtitle").GetComponent<TextMeshProUGUI>();

        PlayerUI = GameObject.Find("PlayerUI").GetComponent<Canvas>();
        campersRemaining = GameObject.Find("CampersRemaining").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }

        campersRemaining.text = campersLeft + " Campers Left!";

        if (gameState == 0)
        {
            PlayerUI.enabled = false;

            if (Input.GetKeyDown(KeyCode.E))
            {
                gameState++;
            }
        }
        else if (gameState == 1)
        {
            IntroUI.enabled = false;
            PlayerUI.enabled = true;

            if (campersLeft == 0)
            {
                gameState++;
            }
        }
        else if (gameState == 2)
        {
            IntroUI.enabled = true;
            subtitle.text = "Press R to Restart";

            if (campersLeft == 0)
            {
                title.text = "Counselors Win!";
            }
            else
            {
                title.text = "Campers Win!";
            }
        }
    }
}
