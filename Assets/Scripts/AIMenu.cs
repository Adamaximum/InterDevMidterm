using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AIMenu : MonoBehaviour
{
    [Header("AI Movement")]
    public bool reverse;
    public float movementSpeed;
    float movementInput;

    public int movementType;
    // 0 = No Movement
    // 1 = Vertical (Z)
    // 2 = Horizontal (X)
    public bool randomize;
    
    void Start()
    {
        if (randomize)
        {
            movementType = Random.Range(1, Mathf.RoundToInt(3));
        }
    }

    void Update()
    {
        AIMovement();
    }
    
    void AIMovement()
    {
        if (movementType == 1) // Vert (Z) Movement
        {
            transform.position += new Vector3(0f, 0f, movementInput);

            if (transform.position.z >= 14)
            {
                reverse = true;
            }
            else if (transform.position.z <= 1)
            {
                reverse = false;
            }

            if (reverse)
            {
                movementInput = -movementSpeed;
            }
            else if (!reverse)
            {
                movementInput = movementSpeed;
            }
        }
        else if (movementType == 2) // Horiz (X) Movement
        {
            transform.position += new Vector3(movementInput, 0f, 0f);

            if (transform.position.x >= 10)
            {
                reverse = true;
            }
            else if (transform.position.x <= -9.6f)
            {
                reverse = false;
            }

            if (reverse)
            {
                movementInput = -movementSpeed;
            }
            else
            {
                movementInput = movementSpeed;
            }
        }
    }
}
