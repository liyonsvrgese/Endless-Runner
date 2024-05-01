using UnityEngine;
using EndlessRunner.Shared;
using System;

namespace EndlessRunner.Player
{
    public class PlayerService : BaseMonoSingletonGeneric<PlayerService>, IPlayerService
    {
        [SerializeField] private GameObject playerPrefab;
        private Transform playerTransform;

        public event Action<int> OnScoreChange;
        public event Action<int> OnCoinsChange;
        public event Action OnGameOver;

        public Transform PlayerPos => playerTransform;

        private int coinsCollected;

        private int currentScore;

        private void Start()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            playerTransform = Instantiate(playerPrefab, this.transform).transform;
        }

        public void UpdateScore(int score)
        {
            if (score <= 0)
            {
                return; 
            }
            currentScore = score;
            OnScoreChange?.Invoke(this.currentScore);
        }

        public void AddCoin(int value)
        {
            if (value <= 0)
            {
                return;
            }
            coinsCollected += value;
            OnCoinsChange?.Invoke(coinsCollected);
        }

        public void TriggerGameOver()
        {
            OnGameOver?.Invoke();
        }
    }
}
