using System;
using _Scirpts;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private EnemySpawnDirector _enemySpawnDirector;

    private void Awake()
    {
        _timer.StartTimer();
        
        _enemySpawnDirector.StartSpawnEnemy();
    }
}
