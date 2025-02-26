﻿using UnityEngine;
using EndlessRunner.Player;
using EndlessRunner.Shared;
using TMPro;

namespace EndlessRunner.UI
{
    class GameOverPanelUi : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI coinText;

        private IPlayerService playerService;

        private void OnEnable()
        {
            playerService = PlayerService.Instance;
            if(playerService == null)
            {
                Debug.LogError("GameOverPanelUI- Start - Playerservice is null");
            }
            SetScoreText(playerService.CurrentScore);
            SetCoinText(playerService.CurrentCoins);

        }

        private void SetScoreText(int score)
        {
            scoreText.text = "Score : " + score;
        }

        private void SetCoinText(int value)
        {
            coinText.text = "Coins : " + value;
        }

        public void RestartScene()
        {
            var appManager = ApplicationManager.Instance;
            if(appManager == null)
            {
                Debug.Log("GameOverPanelUI- RestartScene - ApplicationManager is null");
                return;
            }
            appManager.RestartGame();
        }
    }
}
