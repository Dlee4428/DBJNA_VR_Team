using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    float horizontal, vertical;

    // Update is called once per frame
    void Update()
    {
        horizontal -= 2 * Input.GetAxis("Mouse Y");
        vertical += 2 * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(horizontal, vertical, 0);

        //// VR rotation uncomment when you connect
       
    }
}
