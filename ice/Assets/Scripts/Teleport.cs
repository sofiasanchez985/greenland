using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject TinyUniverse;
    public GameObject NormalRotation;
    public GameObject YRotation;

    void Start()
    {
        Go();
    }

    public void GoScaleUniverse()
    {
        TinyUniverse.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
    }

    public void RotationReset()
    {
        TinyUniverse.transform.rotation = NormalRotation.transform.rotation;
    }

    public void Go()
    {
        TinyUniverse.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        RotationReset();
        TinyUniverse.transform.position = new Vector3(8.8f, -2f, 94f); 
    }

    public void Go2011()
    {
        GoScaleUniverse();
        RotationReset();
        TinyUniverse.transform.position = new Vector3(86.1f, 0f, 923f);
    }

    public void Go2014()
    {
        GoScaleUniverse();
        RotationReset();
        TinyUniverse.transform.position = new Vector3(86.1f, 0f, 898f);
    }

    public void Go2015()
    {
        GoScaleUniverse();
        TinyUniverse.transform.rotation = YRotation.transform.rotation;
        TinyUniverse.transform.position = new Vector3(-902f, 1f, 91f);
    }

    /* Camera Teleportation
    
    public GameObject StartTarget;
    public GameObject BirdTarget;
    public GameObject Target2011;
    public GameObject Target2014;
    public GameObject Target2015;
    public Camera cam;
    public GameObject Universe;

    void ScaleUniverse()
    {
        Vector3 scaleChangeLarge = new Vector3(.1f, .1f, .1f);
        Universe.transform.localScale = scaleChangeLarge;
    }

    public void StartPos()
    {
        Vector3 scaleChangeSmall = new Vector3(.001f, .001f, .001f);
        Universe.transform.localScale = scaleChangeSmall;
        cam.transform.rotation = StartTarget.transform.rotation;
        cam.transform.position = StartTarget.transform.position;
    }

    public void BirdsEye()
    {
        Vector3 scaleChangeSmall = new Vector3(.001f, .001f, .001f);
        Universe.transform.localScale = scaleChangeSmall;
        cam.transform.rotation = BirdTarget.transform.rotation;
        cam.transform.position = BirdTarget.transform.position;
    }

    public void Move2011()
    {
        ScaleUniverse();
        cam.transform.rotation = Target2011.transform.rotation;
        cam.transform.position = Target2011.transform.position;        
    }

    public void Move2014()
    {
        ScaleUniverse();
        cam.transform.rotation = Target2014.transform.rotation;
        cam.transform.position = Target2014.transform.position;
    }

    public void Move2015()
    {
        ScaleUniverse();
        cam.transform.rotation = Target2015.transform.rotation;
        cam.transform.position = Target2015.transform.position;
    }

    */

}
