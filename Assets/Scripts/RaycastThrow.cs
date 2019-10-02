using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastThrow : MonoBehaviour
{
    public Transform dodgeball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        float mouseRayDist = 10000f;

        RaycastHit rayHit = new RaycastHit();

        Debug.DrawRay(mouseRay.origin, mouseRay.direction * mouseRayDist, Color.magenta);

        if (Physics.Raycast(mouseRay, out rayHit, mouseRayDist))
        {
            dodgeball.position = rayHit.point;

            if (Input.GetMouseButton(0))
            {
                Instantiate(dodgeball, rayHit.point, dodgeball.rotation);
            }
        }
    }
}
