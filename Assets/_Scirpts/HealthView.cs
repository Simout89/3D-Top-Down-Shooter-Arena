using System;
using _Scirpts;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        health.OnHealthChanged += HandleHealthChanged;
    }
    
    private void OnDisable()
    {
        health.OnHealthChanged -= HandleHealthChanged;
    }

    private void HandleHealthChanged(float count)
    {
        _slider.value = count;
    }
}
