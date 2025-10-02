using System;
using UnityEngine;

namespace _Scirpts
{
    public class EnemyManager: MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        
        [SerializeField] private Enemy enemy;
        
        [SerializeField] private EnemySpawner _enemySpawner;

        public void SpawnRandomEnemy()
        {
            Enemy newEnemy = _enemySpawner.SpawnRandomEnemy(enemy, playerTransform);
        }

        private void Awake()
        {
            InvokeRepeating("SpawnRandomEnemy", 0, 3);
        }
    }
}