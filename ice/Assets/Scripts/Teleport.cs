using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    //public Vector3 startPos;
    //public Vector3 radar2011pos;
    public GameObject startTarget;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startTarget.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
