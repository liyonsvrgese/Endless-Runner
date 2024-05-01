using UnityEngine;
using System;

namespace EndlessRunner.Player
{
    public interface IPlayerService  
    {
        Transform PlayerPos { get; }    

        event Action<int> OnScoreChange;

        event Action<int> OnCoinsChange;

        event Action<int> OnFuelChange;

        event Action OnGameOver;

        void UpdateScore(int value);

        void AddCoin(int value);

        void UpdateFuel(int value);

        void TriggerGameOver();
    }
}
