using System;
using UnityEngine;

namespace _Scirpts
{
    public class Enemy: MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private float speed = 5f;
        
        private Transform playerTransform;
        
        public void SetPlayerTransform(Transform playerTransform)
        {
            this.playerTransform = playerTransform;
        }

        private void FixedUpdate()
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            Vector3 move = new Vector3(direction.x, 0, direction.z) * (speed * Time.fixedDeltaTime);
            Vector3 nextPosition = transform.position + move;
            rigidbody.MovePosition(nextPosition);
        }
    }
}