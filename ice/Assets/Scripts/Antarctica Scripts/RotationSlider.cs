using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class RotationSlider : MonoBehaviour
{
    public Transform TargetObject;

    public void OnSliderUpdated(SliderEventData eventData)
    {
        float rotate = -90 + (180 * eventData.NewValue);
        TargetObject.localRotation = Quaternion.Euler(0, rotate, 0);
    }

}
