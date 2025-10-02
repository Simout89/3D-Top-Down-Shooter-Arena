using System;
using System.Collections.Generic;
using _Scirpts;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;
    
    [SerializeField] private float damage = 1f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private float radiusAttack = 10f;
    [SerializeField] private float force = 1f;

    private void Awake()
    {
        StartAttack();
    }

    private void StartAttack()
    {
        InvokeRepeating("Attack", 0, attackCooldown);
    }

    private void Attack()
    {
        var colliders = Physics.OverlapSphere(transform.position, radiusAttack);

        List<Collider> damageableColliders = new List<Collider>();

        for (int i = 0; i < colliders.Length; i++)
        {
            if (!colliders[i].GetComponent<PlayerController>() &&
                colliders[i].TryGetComponent(out IDamageable damageable))
                damageableColliders.Add(colliders[i]);
        }

        if(damageableColliders.Count <= 0)
            return;
        
        Collider nearestCollider = damageableColliders[0];

        foreach (var damageableCollider in damageableColliders)
        {
            if (Vector3.Distance(nearestCollider.transform.position, transform.position) >
                Vector3.Distance(damageableCollider.transform.position, transform.position))
            {
                nearestCollider = damageableCollider;
            }
        }

        var projectile = Instantiate(_projectile, transform.position, Quaternion.identity, null);
        
        projectile.Launch((nearestCollider.transform.position - transform.position).normalized * force, damage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radiusAttack);
    }
}
