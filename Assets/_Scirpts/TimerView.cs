using System;
using TMPro;
using UnityEngine;

namespace _Scirpts
{
    public class TimerView: MonoBehaviour
    {
        [SerializeField] private Timer _timer;
        [SerializeField] private TMP_Text _text;

        private void OnEnable()
        {
            _timer.OnTimeChanged += HandleTimeChanged;
        }
        
        private void OnDisable()
        {
            _timer.OnTimeChanged -= HandleTimeChanged;
        }

        private void HandleTimeChanged(float obj)
        {
            _text.text = obj.ToString("F1");
        }
    }
}