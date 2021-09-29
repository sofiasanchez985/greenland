using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class HorizontalSlider : MonoBehaviour
{

    public Transform TargetObject;

    public void OnSliderUpdated(SliderEventData eventData)
    {
        // Rotate the target object using Slider's eventData.NewValue
        TargetObject.localScale = new Vector3(25 + (10 * eventData.NewValue), TargetObject.localScale.y, TargetObject.localScale.z);
        Debug.Log(string.Format("Horizontal: {0}", 25 + (10 * eventData.NewValue)));
    }

}