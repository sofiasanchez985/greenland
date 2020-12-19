using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Camera.main.GetComponent<Camera>().farClipPlane = 15000f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
