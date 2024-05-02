using UnityEngine;
using System;

namespace EndlessRunner.Player
{
    public interface IPlayerService  
    {
        int CurrentScore { get; }

        int CurrentCoins { get; }
        Transform PlayerTransform { get; }

        event Action OnStartGame;

        event Action<int> OnScoreChange;

        event Action<int> OnCoinsChange;

        event Action<int> OnFuelChange;

        event Action OnGameOver;

        void UpdateScore(int value);

        void AddCoin(int value);

        void UpdateFuel(int value);

        void TriggerGameOver();

        void TriggerStartGame();
    }
}
