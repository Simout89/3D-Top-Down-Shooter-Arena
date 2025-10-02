using System;
using UnityEngine;

namespace _Scirpts
{
    public class Projectile: MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        private float damage;

        private void Awake()
        {
            Destroy(gameObject, 15);
        }

        public void Launch(Vector3 direction, float damage)
        {
            this.damage = damage;
            
            _rigidbody.AddForce(direction, ForceMode.Impulse);
        }

        public void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damage);
            }
            
            Destroy(gameObject);
        }
    }
}