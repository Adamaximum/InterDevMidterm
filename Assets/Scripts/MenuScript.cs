using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;

    public Canvas canvas1;
    public Canvas canvas2;
    public Canvas canvas3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginGame()
    {
        Debug.Log("Game has begun!");
        SceneManager.LoadScene("SampleScene");
    }

    public void Story()
    {
        Debug.Log("Here's the story!");
        cam1.enabled = false;
        cam2.enabled = true;
        canvas1.enabled = false;
        canvas2.enabled = true;
    }

    public void HowToPlay()
    {
        Debug.Log("Here's how to play!");
        cam1.enabled = false;
        cam3.enabled = true;
        canvas1.enabled = false;
        canvas3.enabled = true;
    }

    public void Back()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
        canvas1.enabled = true;
        canvas2.enabled = false;
        canvas3.enabled = false;
    }
}
