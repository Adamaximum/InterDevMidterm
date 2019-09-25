using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float horizontalLookSpeed = 10f;
    public float verticalLookSpeed = 5f;

    float verticalAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.parent.Rotate(0f, mouseX * horizontalLookSpeed, 0f);

        verticalAngle -= mouseY * verticalLookSpeed;
        verticalAngle = Mathf.Clamp(verticalAngle, -80f, 80f);

        transform.localEulerAngles = new Vector3(verticalAngle, transform.localEulerAngles.y, 0f);
    }
}
