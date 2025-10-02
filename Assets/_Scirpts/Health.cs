using System;
using UnityEngine;

namespace _Scirpts
{
    public class Health: MonoBehaviour, IDamageable
    {
        [SerializeField] private float maxHealthPoint;

        private float currentHealthPoint;

        public event Action OnDie;
        public event Action<float> OnHealthChanged; 

        private void Awake()
        {
            currentHealthPoint = maxHealthPoint;
        }

        public void TakeDamage(float count)
        {
            currentHealthPoint -= count;
            
            OnHealthChanged?.Invoke(currentHealthPoint);

            if (currentHealthPoint <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            OnDie?.Invoke();
            
            Destroy(gameObject);
        }
    }
}