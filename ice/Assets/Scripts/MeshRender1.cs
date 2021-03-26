using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class MeshRender1 : MonoBehaviour
{

    // eliminate ySize, it's one bc one triangle only yeet
    // make the yStart or yEnd positions translate onto where the mesh starts automatically
    // correct values on 2011 and 2011-2015 flipped
    // basically went around the issue and made a big triangle rather than +6,000 small layers(:

    // Mesh tutorial vars
    public int xSize, ySize;
    //public GameObject meshObject;
    public Transform mytransform;
    private Vector3[] vertices;
    private Mesh mesh;

    // Bottom of ice sheet
    public float yStart;
    public float yEnd;
    private float radarHeight;

    // Name of the input file, no extension
    public string inputfile;

    // List for holding data from CSV reader
    private List<Dictionary<string, object>> pointList;

    // Indices for columns to be assigned
    public int columnX = 0;
    public int columnZ = 1;

    // Scale the model
    public float scaleFactor = 0.1F;

    // Full column names
    public string xName;
    public string zName;

    private void Awake()
    {
        ProcessData();
        //Generate();
        StartCoroutine(Generate());
    }

    private void ProcessData()
    {

        // Process CSV Data
        pointList = CSVReader.Read(inputfile);

        //float radarHeightF = (yEnd - yStart) * scaleFactor;
        //radarHeight = (int)radarHeightF;
        radarHeight = Math.Abs(yEnd - yStart) * scaleFactor;

        // Declare list of strings, fill with keys (column names)
        // The index of pointList doesn't matter, keys are same for every dictionary
        List<string> columnList = new List<string>(pointList[0].Keys);

        // Print number of keys (using .count)
        Debug.Log("There are " + columnList.Count + " columns in CSV");

        foreach (string key in columnList)
            Debug.Log("Column name is " + key);

        Debug.Log("point list count: " + pointList.Count);

        // Assign column name from columnList to Name variables
        xName = columnList[columnX];
        zName = columnList[columnZ];

    }

    //do stuff with camera

    private IEnumerator Generate()
    //private void Generate()
    {
        WaitForSeconds wait = new WaitForSeconds(0.0001f);

        Debug.Log("GOING");

        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural Grid";

        Debug.Log("first y/z value: " + pointList[0][zName]);

        // Added Math.Abs(yStart) to size in order to fit negative y start values
        // declaring a list of Vector3's with the size of the horizonal point list * height of the mesh
        //vertices = new Vector3[(pointList.Count + 1) * (ySize + Math.Abs(yStart) + 1)];
        // one bc one triangle 11!!1!!!!!!!!
        vertices = new Vector3[(pointList.Count + 1) * (1 + 1)];
        Vector2[] uv = new Vector2[vertices.Length];

        //for (int y = yStart, w = 0; y <= ySize; y++)
        for (int y = 0, w = 0; y <= ySize; y++)
        {
            //changed from <= to <
            for (int i = 0; i < pointList.Count; i++, w++)
            {
                float xPos = (float)pointList[i][xName] * scaleFactor;
                float zPos = (float)pointList[i][zName] * scaleFactor;
                vertices[w] = new Vector3(xPos, y * radarHeight, zPos);

                // Spheres for testing/debugging

                //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                //sphere.transform.position = new Vector3((float)xPos, y * 100, (float)zPos);
                //sphere.transform.position = new Vector2((float)xPos / pointList.Count, (float)y / ySize);

                // Mapping coordinates to fit between 0,1

                float xStart = (float)pointList[0][xName];
                float xEnd = (float)pointList[pointList.Count - 1][xName];
                float xCurrent = (float)pointList[i][xName];
                float xUV = (xCurrent - xStart) / (xEnd - xStart);

                uv[w] = new Vector2(xUV, (float)y / ySize);
            }
        }
        mesh.vertices = vertices;
        mesh.uv = uv;

        int[] triangles = new int[(pointList.Count) * ySize * 6];
        for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++)
        {
            //subtracted one from pointList.Count to make sure #vertices = #indices
            for (int x = 0; x < pointList.Count - 1; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                //subtracted one from pointList.Count
                triangles[ti + 4] = triangles[ti + 1] = vi + pointList.Count;
                //subtracted one from pointList.Count
                triangles[ti + 5] = vi + pointList.Count + 1;
                mesh.triangles = triangles;
                yield return wait;
            }
        }
        //mesh.triangles = triangles;
        //yield return wait;
        mesh.RecalculateNormals();

        
        float yPosScaled = yStart * scaleFactor;
        Debug.Log("YPOS " + yPosScaled);
        //meshObject.transform.position = new Vector3(0, 0, 0);
        mytransform.localPosition = new Vector3(0, yPosScaled, 0);
        Debug.Log("position: " + mytransform.localPosition);
        
    }

    /*
    private void FixedUpdate()
    {
        //float yPosScaled = yStart * scaleFactor;
        //Debug.Log("YPOS " + yPosScaled);
        //meshObject.transform.position = new Vector3(0, 0, 0);
        //meshObject.transform.position = new Vector3(0, yPosScaled, 0);
        Debug.Log("transform print " + mytransform.position);
    }
    */

}
