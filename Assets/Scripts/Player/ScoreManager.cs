using UnityEngine;
using EndlessRunner.Shared;

namespace EndlessRunner.Player
{
    public class ScoreManager : MonoBehaviour
    {
        private IPlayerService playerService;
        private int currentScore;
        private float timer = 0f;
        private bool isGameRunning = false;
        private void OnEnable()
        {
            playerService = PlayerService.Instance;
            playerService.OnStartGame += StartGame;
            playerService.OnGameOver += OnGameOver;
        }

        private void OnDisable()
        {
            playerService.OnStartGame -= StartGame;
            playerService.OnGameOver += OnGameOver;
        }

        private void Update()
        {
            if (isGameRunning)
            {
                timer += Time.deltaTime * GameConstants.SCORE_RATE;

                if (Mathf.FloorToInt(timer) > currentScore)
                {
                    currentScore++;
                    playerService.UpdateScore(currentScore);
                }
            }
        }
        private void StartGame()
        {
            isGameRunning = true;
        }

        private void OnGameOver()
        {
            isGameRunning = false;
        }
    }
}
