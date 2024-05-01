using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EndlessRunner.Player;
using EndlessRunner.Shared;

namespace EndlessRunner.UI
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private GameObject gameUi;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI coinsText;
        [SerializeField] private Slider fuelSlider;
        [SerializeField] private Image fuelSliderFillImage;

        private IPlayerService playerService;       

        private void OnEnable()
        {           
            playerService = PlayerService.Instance;
            if (playerService == null)
            {
                Debug.LogError("UiManager- OnEnable : Player Service us null");
                return;
            }
            playerService.OnCoinsChange += SetCoinsText;
            playerService.OnScoreChange += SetScoreText;
            playerService.OnFuelChange += SetFuelValue;
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
            fuelSlider.maxValue = GameConstants.MAX_FUEL; 
            fuelSlider.value = GameConstants.MAX_FUEL;
            
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
            if (playerService == null)
            {
                Debug.LogError("UiManager- OnDisable : Player Service us null");
                return;
            }
            playerService.OnCoinsChange -= SetCoinsText;
            playerService.OnScoreChange -= SetScoreText;
            playerService.OnFuelChange -= SetFuelValue;
        }

        private void SetFuelValue(int value)
        {
            fuelSlider.value = value;
            float normalizedValue = fuelSlider.value / fuelSlider.maxValue;

            Color color;

            if (normalizedValue >= 0.5f) 
            {
                color = Color.Lerp(Color.yellow, Color.green, (normalizedValue - 0.5f) * 2f);
            }
            else
            {
                color = Color.Lerp(Color.red, Color.yellow, normalizedValue * 2f);
            }       
            
            fuelSliderFillImage.color = color;
        }
    }
}
