using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class VerticalSlider : MonoBehaviour
{
    public Transform TargetObject;
    //private float OriginalHeight;
    //private BoxCollider CurrentCollider;
    //public float scale;

    /*
    private void Start()
    {
        CurrentCollider = TargetObject.GetComponent<BoxCollider>();
        OriginalHeight = CurrentCollider.bounds.size.y * scale;
    }
    */

    public void OnSliderUpdated(SliderEventData eventData)
    {
        TargetObject.localScale = new Vector3(TargetObject.localScale.x, 5 + (10 * eventData.NewValue), TargetObject.localScale.z);
    }

}