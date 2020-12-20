using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject StartTarget;
    public GameObject BirdTarget;
    public GameObject Target2011;
    public GameObject Target2014;
    public GameObject Target2015;
    public Camera cam;
    public GameObject Universe;

    // Start is called before the first frame update
    void Start()
    {
        StartPos();
        //cam.transform.position = StartTarget.transform.position;
    }

    /*
    void ResetCamera()
    {
        cam.transform.position = Vector3.zero;
    }
    */
    
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

    // Update is called once per frame
    void Update()
    {

    }

}
