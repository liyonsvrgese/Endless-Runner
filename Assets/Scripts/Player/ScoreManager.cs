using UnityEngine;
using EndlessRunner.Player;
using EndlessRunner.Shared;

namespace EndlessRunner
{
    public class ScoreManager : MonoBehaviour
    {
        private IPlayerService playerService;
        private int currentScore;

        private int roundedScore;

        private float timer = 0f;

        private void Start()
        {
            playerService = PlayerService.Instance;
        }

        private void Update()
        {
            timer += Time.deltaTime * GameConstants.SCORE_RATE;

            roundedScore = Mathf.FloorToInt(timer);
            if ( roundedScore > currentScore)
            {
                currentScore++;
                playerService.UpdateScore(currentScore);
            }
        }
    }
}
