using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scirpts
{
    public class Enemy: MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidBody;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float damage = 1f;
        [SerializeField] private float attackCooldown = 0.5f;
        
        private Transform playerTransform;
        private Coroutine attackCoroutine;
        
        public void SetPlayerTransform(Transform playerTransform)
        {
            this.playerTransform = playerTransform;
        }

        private void FixedUpdate()
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            Vector3 move = new Vector3(direction.x, 0, direction.z) * (speed * Time.fixedDeltaTime);
            Vector3 nextPosition = transform.position + move;
            rigidBody.MovePosition(nextPosition);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.GetComponent<PlayerController>() &&
                other.collider.TryGetComponent(out IDamageable damageable))
            {
                if(attackCoroutine != null)
                    StopCoroutine(attackCoroutine);
                
                attackCoroutine = StartCoroutine(AttackCoroutine(damageable));
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.collider.GetComponent<PlayerController>() &&
                other.collider.TryGetComponent(out IDamageable damageable))
            {
                if (attackCoroutine != null)
                    StopCoroutine(attackCoroutine);
            }
        }

        private IEnumerator AttackCoroutine(IDamageable damageable)
        {
            while (true)
            {
                damageable.TakeDamage(damage);
                yield return new WaitForSeconds(attackCooldown);
            }
        }
    }
}