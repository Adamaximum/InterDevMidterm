using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpExperiment : MonoBehaviour
{
    float jumpStrength = 2f;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    void Jump()
    {
        if (CanJump())
        {
            // Jump on ridigbody
            GetComponent<Rigidbody>().AddForce(jumpStrength * transform.up, ForceMode.Impulse);
        }
    }

    bool CanJump()
    {
        // Create Ray
        Ray ray = new Ray(transform.position, transform.up * -1);

        // Create Hit Info
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, transform.localScale.y + 0.2f))
        {
            return true;
        }

        // Nothing so return false
        return false;
    }
}
