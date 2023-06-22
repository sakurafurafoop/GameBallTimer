using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPosition : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public void ResetPositon(int scale)
    {
        slider.maxValue = scale;
        slider.value = slider.maxValue / 2;
    }

    public int GetValue()
    {
        return (int)slider.value;
    }
}
