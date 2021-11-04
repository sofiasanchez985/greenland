using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class VerticalSlider : MonoBehaviour
{
    public Transform TargetObject;

    public void OnSliderUpdated(SliderEventData eventData)
    {
        TargetObject.localScale = new Vector3(TargetObject.localScale.x, 5 + (10 * eventData.NewValue), TargetObject.localScale.z);
    }

}