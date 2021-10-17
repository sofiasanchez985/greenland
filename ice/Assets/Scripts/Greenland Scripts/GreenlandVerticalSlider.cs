using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class GreenlandVerticalSlider : MonoBehaviour
{

    public Transform IceSheet;

    public void OnSliderUpdated(SliderEventData eventData)
    {
        // Rotate the target object using Slider's eventData.NewValue
        IceSheet.localScale = new Vector3(IceSheet.localScale.x, 4 * eventData.NewValue, IceSheet.localScale.z);
    }

}