using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider _slider;
    public Color _low;
    public Color _high;
    public Vector3 _offset;
    public Image _fill;

    private void Update()
    {
        _slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + _offset);
    }

    public void SetMaxHP(float hp)
    {
        _slider.maxValue = hp;
        _slider.value = hp;

        _fill.color = Color.Lerp(_low, _high, _slider.normalizedValue);
    }

    public void SetHP(float hp)
    {
        _slider.value = hp;
        _fill.color = Color.Lerp(_low, _high, _slider.normalizedValue);
    }
}