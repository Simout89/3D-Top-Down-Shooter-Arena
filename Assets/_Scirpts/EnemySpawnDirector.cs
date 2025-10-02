using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scirpts
{
    public class EnemySpawnDirector: MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Enemy[] enemyPrefabs;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private Timer _timer;

        public void SpawnRandomEnemy()
        {
            Enemy newEnemy = _enemySpawner.SpawnRandomEnemy(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], playerTransform);
        }

        public void StartSpawnEnemy()
        {
            StartCoroutine(SpawnEnemyCoroutine());
        }

        private IEnumerator SpawnEnemyCoroutine()
        {
            while (true)
            {
                SpawnRandomEnemy();
                yield return new WaitForSeconds((float)(1 - 0.01 * _timer.CurrentTime));
            }
        }
    }
}