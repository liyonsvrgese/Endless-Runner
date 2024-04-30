using UnityEngine;
using TMPro;

namespace EndlessRunner.UI
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private GameObject gameUi;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI coinsText;

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
    }
}
