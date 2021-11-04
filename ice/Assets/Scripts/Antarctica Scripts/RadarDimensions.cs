using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Microsoft.MixedReality.Toolkit.UI;

public class RadarDimensions : MonoBehaviour
{
    // Radar collider & scale factor
    public GameObject RadarQuad;
    private BoxCollider CurrentCollider;
    public float scale;

    // Transform.scale values
    private float scaleX;
    private float scaleY;
    private float scaleZ;

    // Dimension calculations
    private float OriginalHeight;
    private float OriginalWidth;
    private float ScaledHeight;
    private float ScaledWidth;
    private float StrainHeight;
    private float StrainWidth;

    // Text objects
    public GameObject VerticalOriginalText;
    private TextMeshPro VerticalOriginalTMP;
    public GameObject HorizontalOriginalText;
    private TextMeshPro HorizontalOriginalTMP;
    public GameObject VerticalScaleText;
    private TextMeshPro VerticalScaleTMP;
    public GameObject HorizontalScaleText;
    private TextMeshPro HorizontalScaleTMP;
    public GameObject VerticalStrainText;
    private TextMeshPro VerticalStrainTMP;
    public GameObject HorizontalStrainText;
    private TextMeshPro HorizontalStrainTMP;
    public GameObject RotationDegreeText;
    private TextMeshPro RotationDegreeTMP;

    void Start()
    {
        CurrentCollider = RadarQuad.GetComponent<BoxCollider>();

        // Set original scale values
        scaleX = RadarQuad.transform.localScale.x;
        scaleY = RadarQuad.transform.localScale.y;
        scaleZ = RadarQuad.transform.localScale.z;

        // Set original dimension values
        OriginalHeight = CurrentCollider.bounds.size.y * scale;
        OriginalWidth = CurrentCollider.bounds.size.x * scale;
        VerticalOriginalTMP = VerticalOriginalText.GetComponent<TextMeshPro>(); // going to need a database for this/some spreadsheet with the values
        VerticalOriginalTMP.text = string.Format("Original:   {0} m", OriginalHeight.ToString());
        HorizontalOriginalTMP = HorizontalOriginalText.GetComponent<TextMeshPro>(); // going to need a database for this/some spreadsheet with the values
        HorizontalOriginalTMP.text = string.Format("Original:   {0} m", OriginalWidth.ToString());

        // Instantiate current scaled and strain values
        ScaledHeight = ScaledWidth = StrainHeight = StrainWidth = 0;
        VerticalScaleTMP = VerticalScaleText.GetComponent<TextMeshPro>();
        HorizontalScaleTMP = HorizontalScaleText.GetComponent<TextMeshPro>();
        VerticalStrainTMP = VerticalStrainText.GetComponent<TextMeshPro>();
        HorizontalStrainTMP = HorizontalStrainText.GetComponent<TextMeshPro>();

        // Instantiate and set rotation
        RotationDegreeTMP = RotationDegreeText.GetComponent<TextMeshPro>();
        RotationDegreeTMP.text = RadarQuad.transform.rotation.y.ToString();
    }

    void Update()
    {
        // Get current dimensions of the radar image
        ScaledHeight = CurrentCollider.bounds.size.y * scale;
        ScaledWidth = CurrentCollider.bounds.size.x * scale;

        // Set scaled dimensions text
        VerticalScaleTMP.text = string.Format("Current:    {0} m", ScaledHeight.ToString());
        HorizontalScaleTMP.text = string.Format("Current:    {0} m", ScaledWidth.ToString());

        // Calculate strain
        StrainHeight = Math.Abs(OriginalHeight - ScaledHeight);
        StrainWidth = Math.Abs(OriginalWidth - ScaledWidth);

        // Set strain text
        VerticalStrainTMP.text = string.Format("Strain:       {0}", StrainHeight.ToString());
        HorizontalStrainTMP.text = string.Format("Strain:       {0}", StrainWidth.ToString());

        // Set rotation text
        RotationDegreeTMP.text = string.Format("{0}°", RadarQuad.transform.localEulerAngles.y.ToString());

        /*
        Debug.Log(string.Format("ColliderY: {0}", collider.bounds.size.y.ToString()));
        Debug.Log(string.Format("ColliderX: {0}", collider.bounds.size.x.ToString()));
        Debug.Log(string.Format("VerticalDimText: {0}", ScaledHeight.ToString()));
        Debug.Log(string.Format("HorizontalDimText: {0}", ScaledWidth.ToString()));
        */
    }

    public void OnVerticalSliderUpdated(SliderEventData eventData)
    {
        float scaleValue = 1 + eventData.NewValue;
        RadarQuad.transform.localScale = new Vector3(scaleX, scaleY * scaleValue, scaleZ);
    }

    public void OnHorizontalSliderUpdated(SliderEventData eventData)
    {
        float scaleValue = 1 + eventData.NewValue;
        RadarQuad.transform.localScale = new Vector3(scaleX * scaleValue, scaleY, scaleZ);
    }

    public void OnRotateSliderUpdated(SliderEventData eventData)
    {
        float rotate = -90 + (180 * eventData.NewValue);
        RadarQuad.transform.localRotation = Quaternion.Euler(0, rotate, 0);
    }

}
