using System;
using TMPro;

using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public RectTransform experienceValueRectTransform;
    
    private int _levelValue = 1;
    
    private float _experienceCurrentValue = 0;
    private float _experienceTargetValue = 100;

    public TextMeshProUGUI levelValueTMP;

    public void Start()
    {
        DrawUI();
    }

    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;
        if (_experienceCurrentValue >= _experienceTargetValue)
        {
            _levelValue += 1;
            _experienceCurrentValue = 0;
        }
        DrawUI();
    }

    public void DrawUI()
    {
        experienceValueRectTransform.anchorMax = new Vector2(_experienceCurrentValue / _experienceTargetValue, 1);
        levelValueTMP.text = _levelValue.ToString();
    }
}
