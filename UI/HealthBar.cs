using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider _slider;
    public Gradient _gradient;
    public Image _fill;

    public void SetMaxHP(float hp)
    {
        _slider.maxValue = hp;
        _slider.value = hp;

        _fill.color = _gradient.Evaluate(1f);
    }

    public void SetHP(float hp)
    {
        _slider.value = hp;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
}
