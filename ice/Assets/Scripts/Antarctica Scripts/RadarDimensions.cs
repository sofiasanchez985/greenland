using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RadarDimensions : MonoBehaviour
{
    //private RectTransform rectTransform;
    private BoxCollider collider;
    public float scale;
    public GameObject RadarQuad;
    public GameObject VerticalScaleText;
    public GameObject HorizontalScaleText;
    private TextMeshPro VerticalDimension;
    private TextMeshPro HorizontalDimension;

    // Start is called before the first frame update
    void Start()
    {
        collider = RadarQuad.GetComponent<BoxCollider>();
        VerticalDimension = VerticalScaleText.GetComponent<TextMeshPro>();
        HorizontalDimension = HorizontalScaleText.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(string.Format("rectTransform height: {0}", rectTransform.rect.height.ToString()));
        float ScaledHeight = collider.bounds.size.y * scale;
        float ScaledWidth = collider.bounds.size.x * scale;
        VerticalDimension.text = string.Format("{0} M", ScaledHeight.ToString());
        HorizontalDimension.text = string.Format("{0} M", ScaledWidth.ToString());
        Debug.Log(string.Format("ColliderY: {0}", collider.bounds.size.y.ToString()));
        Debug.Log(string.Format("ColliderX: {0}", collider.bounds.size.x.ToString()));
        Debug.Log(string.Format("VerticalDimText: {0}", ScaledHeight.ToString()));
        Debug.Log(string.Format("HorizontalDimText: {0}", ScaledWidth.ToString()));
    }
}
