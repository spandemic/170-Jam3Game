using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void SetMaxHunger(int hunger)
    {
        slider.maxValue = hunger;
        slider.value = 0;
        fill.color = gradient.Evaluate(0);
    }
    public void SetHunger(int hunger)
    {
        slider.value = hunger;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
