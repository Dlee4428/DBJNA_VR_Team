using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    float horizontal, vertical;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal -= 2 * Input.GetAxis("Mouse Y");
        vertical += 2 * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(horizontal, vertical, 0);
    }
}
