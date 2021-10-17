using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class VerticalSlider : MonoBehaviour
{

    public Transform TargetObject;

    public void OnSliderUpdated(SliderEventData eventData)
    {
        // Rotate the target object using Slider's eventData.NewValue
        TargetObject.localScale = new Vector3(TargetObject.localScale.x, 5 + (10 * eventData.NewValue), TargetObject.localScale.z);
        Debug.Log(string.Format("Vertical: {0}", 5 + (10 * eventData.NewValue)));
    }

}