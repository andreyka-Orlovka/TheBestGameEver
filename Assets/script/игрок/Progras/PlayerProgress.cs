using System;
using System.Collections.Generic;
using TMPro;

using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public List<PlayerProgressLevel> ListProgress;
    
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
            AddLevelValue(_levelValue + 1);
            _experienceCurrentValue = 0;
        }
        DrawUI();
    }

    public void AddLevelValue(int value)
    {
        _levelValue = value;
    }

    public void DrawUI()
    {
        experienceValueRectTransform.anchorMax = new Vector2(_experienceCurrentValue / _experienceTargetValue, 1);
        levelValueTMP.text = _levelValue.ToString();
    }
}
