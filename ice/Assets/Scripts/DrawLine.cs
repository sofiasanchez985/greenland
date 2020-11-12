using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private float counter;
    private float dist;

    public Transform origin;
    public Transform destination;

    public TextMeshProUGUI distText;

    // Start is called before the first frame update
    void Start()
    {
        distText = FindObjectOfType<TextMeshProUGUI>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, destination.position);
        lineRenderer.SetWidth(0.45f, 0.45f);

        dist = Vector3.Distance(origin.position, destination.position);
        distText.SetText($"Distance: {dist} m");
    }

    // Update is called once per frame
    void Update()
    {
        
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, destination.position);
        dist = Vector3.Distance(origin.position, destination.position);
        distText.SetText($"Distance: {dist} m");
    }
}
