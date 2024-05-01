using UnityEngine;
using EndlessRunner.Shared;

namespace EndlessRunner.Player
{
    public class ScoreManager : MonoBehaviour
    {
        private IPlayerService playerService;
        private int currentScore;
        private float timer = 0f;

        private void Start()
        {
            playerService = PlayerService.Instance;
        }

        private void Update()
        {
            timer += Time.deltaTime * GameConstants.SCORE_RATE;

            if (Mathf.FloorToInt(timer) > currentScore)
            {
                currentScore++;
                playerService.UpdateScore(currentScore);
            }
        }
    }
}
