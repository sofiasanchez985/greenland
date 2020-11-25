using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private float dist;

    public Transform origin;
    public Transform dest;
    private float dist_in_km;
    public TextMeshPro distText1;
    public TextMeshPro distText2;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, dest.position);
        lineRenderer.SetWidth(.45f, .45f);

        dist = Vector3.Distance(origin.position, dest.position);
        dist_in_km = dist * 0.01f;
        distText1.SetText($"Distance:{dist_in_km.ToString("0.0000")} km");
        distText2.SetText($"Distance:{dist_in_km.ToString("0.0000")} km");
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, dest.position);
        dist = Vector3.Distance(origin.position, dest.position);
        dist_in_km = dist * 0.01f;
        distText1.SetText($"Distance:{dist_in_km.ToString("0.0000")} km");
        distText2.SetText($"Distance:{dist_in_km.ToString("0.0000")} km");
    }
}
