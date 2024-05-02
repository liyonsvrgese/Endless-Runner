using UnityEngine;
using EndlessRunner.Shared;
using System;

namespace EndlessRunner.Player
{
    public class PlayerService : BaseMonoSingletonGeneric<PlayerService>, IPlayerService
    {
        [SerializeField] private GameObject playerPrefab;

        private Transform playerTransform;
        private int coinsCollected;
        private int currentScore;
        private int currentFuel;

        public event Action<int> OnScoreChange;
        public event Action<int> OnCoinsChange;
        public event Action OnGameOver;
        public event Action<int> OnFuelChange;
        public event Action OnStartGame;

        public Transform PlayerTransform => playerTransform;

        public int CurrentScore => currentScore;

        public int CurrentCoins => coinsCollected;

        private void Start()
        {
            SpawnPlayer();
            currentFuel = GameConstants.MAX_FUEL;
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

        public void UpdateFuel(int current)
        {
            if(current ==0)
            {
                Debug.Log(Time.time);
                TriggerGameOver();
            }
            currentFuel = current;
            OnFuelChange?.Invoke(currentFuel);
        }

        public void TriggerStartGame()
        {
            OnStartGame?.Invoke();
        }
    }
}
