using System;
using System.Collections;
using UnityEngine;

namespace _Scirpts
{
    public class Timer: MonoBehaviour
    {
        private float currentTime = 0;
        
        public float CurrentTime => currentTime;

        public event Action<float> OnTimeChanged; 
        
        public void StartTimer()
        {
            StartCoroutine(TimerTick());
        }

        private IEnumerator TimerTick()
        {
            while (true)
            {
                currentTime += Time.deltaTime;
                OnTimeChanged?.Invoke(currentTime);
                yield return null;
            }
        }
    }
}