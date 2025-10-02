using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scirpts
{
    public class GameManager: MonoBehaviour
    {
        [SerializeField] private Health playerHealth;

        private void OnEnable()
        {
            playerHealth.OnDie += HandlePlayerDie;
        }
        
        private void OnDisable()
        {
            playerHealth.OnDie -= HandlePlayerDie;
        }

        private void HandlePlayerDie()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}