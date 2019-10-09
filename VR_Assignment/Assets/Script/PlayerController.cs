using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseInput = Input.GetAxis("Mouse X");
        float mouseInputY = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButton(0))
        {
            Vector3 lookhere = new Vector3(-mouseInputY, mouseInput, 0);
            transform.Rotate(lookhere);
        }
    }
}
