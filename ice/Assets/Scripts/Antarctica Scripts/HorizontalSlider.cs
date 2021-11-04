﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class HorizontalSlider : MonoBehaviour
{

    public Transform TargetObject;

    public void OnSliderUpdated(SliderEventData eventData)
    {
        TargetObject.localScale = new Vector3(25 + (10 * eventData.NewValue), TargetObject.localScale.y, TargetObject.localScale.z);
    }

}