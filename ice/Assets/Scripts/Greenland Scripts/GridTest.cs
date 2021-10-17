using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class GridTest : MonoBehaviour
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
    public int columnY = 1;

    // Scale the model
    public float scaleFactor = 0.05F;

    // Full column names
    public string xName;
    public string yName;

    private void Awake()
    {
        //StartCoroutine(Generate());
        Generate();
    }

    /*
    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }
        Gizmos.color = Color.black;
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }
    */

    private void Generate()
    {
        //WaitForSeconds wait = new WaitForSeconds(0.005f);

        // DataPlotter code

        // Process CSV Data
        pointList = CSVReader.Read(inputfile);

        //Log to console
        Debug.Log(pointList);

        // Declare list of strings, fill with keys (column names)
        List<string> columnList = new List<string>(pointList[1].Keys);

        // Print number of keys (using .count)
        Debug.Log("There are " + columnList.Count + " columns in CSV");

        foreach (string key in columnList)
            Debug.Log("Column name is " + key);

        // Assign column name from columnList to Name variables
        xName = columnList[columnX];
        yName = columnList[columnY];

        /*
        //Loop through Pointlist
        for (var i = 0; i < pointList.Count; i++)
        {
            // Get value in poinList at ith "row", in "column" Name
            float x = System.Convert.ToSingle(pointList[i][xName]);
            float z = System.Convert.ToSingle(pointList[i][zName]);

            //instantiate the prefab with coordinates defined above
            GameObject tempSphere = Instantiate(PointPrefab, new Vector3(x * scaleFactor, y * scaleFactor, z * scaleFactor), Quaternion.identity, Parent.transform);
            tempSphere.transform.localPosition = new Vector3(x * scaleFactor, y * scaleFactor, z * scaleFactor);

        }
        */

        // Generate() code, modified
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural Grid";

        
        vertices = new Vector3[(pointList.Count + 1) * (pointList.Count + 1)];
        Vector2[] uv = new Vector2[vertices.Length];

        for (var i = 0; i < pointList.Count; i++)
        {
            // Get value in poinList at ith "row", in "column" Name
            float x = System.Convert.ToSingle(pointList[i][xName]);
            float y = System.Convert.ToSingle(pointList[i][yName]);

            Debug.Log("x y coords are " + x + " " + y);

            vertices[i] = new Vector3(x, y);
            uv[i] = new Vector2((float)x / pointList.Count, (float)y / pointList.Count);

        }

        /*
        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                vertices[i] = new Vector3(x, y);
                uv[i] = new Vector2((float)x / xSize, (float)y / ySize);
            }
        }
        */
        mesh.vertices = vertices;
        mesh.uv = uv;

        int[] triangles = new int[pointList.Count * pointList.Count * 6];
        for (int ti = 0, vi = 0, y = 0; y < pointList.Count; y++, vi++)
        {
            for (int x = 0; x < pointList.Count; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + pointList.Count + 1;
                triangles[ti + 5] = vi + pointList.Count + 2;
            }
        }

        /*
        int[] triangles = new int[xSize * ySize * 6];
        for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++)
        {
            for (int x = 0; x < xSize; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
                triangles[ti + 5] = vi + xSize + 2;
            }
        }
        */
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

}
