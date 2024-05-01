using UnityEngine;
using TMPro;
using EndlessRunner.Player;

namespace EndlessRunner.UI
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private GameObject gameUi;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI coinsText;

        private IPlayerService playerService;       

        private void OnEnable()
        {
            playerService = PlayerService.Instance;
            playerService.OnCoinsChange += SetCoinsText;
            playerService.OnScoreChange += SetScoreText;
        }
        private void Start()
        {
            OnGameStart();        
        }
     
        private void OnGameStart()
        {
            gameUi.SetActive(true);
            SetScoreText(0);
            SetCoinsText(0);
        }

        private void OnGameOver()
        {
            gameUi.SetActive(false);
            gameOverPanel.SetActive(true);
        }

        private void SetScoreText(int value)
        {
            scoreText.text = "Score : " + value.ToString();
        }

        private void SetCoinsText(int value)
        {
            coinsText.text = "Coins : " + value.ToString();
        }

        private void OnDisable()
        {
            playerService.OnCoinsChange -= SetCoinsText;
            playerService.OnScoreChange -= SetScoreText;
        }
    }
}
