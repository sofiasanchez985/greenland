using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holoportation : MonoBehaviour
{

    public GameObject Antarctica;

    // Start is called before the first frame update
    void Start()
    {
        Antarctica.transform.position = new Vector3(-10.7f, 11f, 151.2f);
    }

    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
