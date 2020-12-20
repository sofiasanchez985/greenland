using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View2011 : MonoBehaviour
{
    public GameObject radarView;

// Start is called before the first frame update
void Start()
    {
        if (enabled)
        {
            transform.position = radarView.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
