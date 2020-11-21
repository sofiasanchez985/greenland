using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class GridTest2 : MonoBehaviour
{
    // Mesh tutorial vars
    public int xSize, ySize;
    private Vector3[] vertices;
    private Mesh mesh;

    // Name of the input file, no extension
    public string inputfile;

    // List for holding data from CSV reader
    private List<Dictionary<string, object>> pointList;

    // Indices for columns to be assigned
    public int columnX = 0;
    public int columnZ = 1;

    // Scale the model
    public float scaleFactor = 0.05F;

    // Full column names
    public string xName;
    public string zName;

    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {

        // Process CSV Data
        pointList = CSVReader.Read(inputfile);

        // Declare list of strings, fill with keys (column names)
        List<string> columnList = new List<string>(pointList[1].Keys);

        // Print number of keys (using .count)
        Debug.Log("There are " + columnList.Count + " columns in CSV");

        foreach (string key in columnList)
            Debug.Log("Column name is " + key);

        Debug.Log("point list count: " + pointList.Count);

        // Assign column name from columnList to Name variables
        xName = columnList[columnX];
        zName = columnList[columnZ];

        ////

        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural Grid";

        Debug.Log("first y/z value: " + pointList[0][zName]);

        vertices = new Vector3[(pointList.Count+1) * (ySize+1)];
        //Vector2[] uv = new Vector2[vertices.Length];
        for (int y = 0, w = 0; y <= ySize; y++)
        {
            //changed from <= to <
            for (int i = 0; i < pointList.Count; i++, w++)
            {
                vertices[w] = new Vector3((float)pointList[i][xName] * scaleFactor, y * 100, (float)pointList[i][zName] * scaleFactor);
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = new Vector3((float)pointList[i][xName] * scaleFactor, y * 100, (float)pointList[i][zName] * scaleFactor);
                //uv[i] = new Vector2((float)x / xSize, (float)y / ySize);
                //Debug.Log("x: ", );
            }
        }
        mesh.vertices = vertices;
        //mesh.uv = uv;

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
            }
        }
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

}
