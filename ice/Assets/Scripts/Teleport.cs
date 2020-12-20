using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject StartTarget;
    public GameObject Target2011;
    public GameObject Target2014;
    public GameObject Target2015;
    public Camera cam;

    //add rotations to camera
    //fix positions each thing goes to
    //scale up the universe!!

    // Start is called before the first frame update
    void Start()
    {
        cam.transform.position = StartTarget.transform.position;
    }

    void ResetCamera()
    {
        cam.transform.position = Vector3.zero;
    }

    public void StartPos()
    {
        cam.transform.position = StartTarget.transform.position;
    }


    public void Move2011()
    {
        cam.transform.position = Target2011.transform.position;
    }

    public void Move2014()
    {
        cam.transform.position = Target2014.transform.position;
    }

    public void Move2015()
    {
        cam.transform.position = Target2015.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
