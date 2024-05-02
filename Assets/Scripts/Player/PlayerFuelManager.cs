using UnityEngine;
using EndlessRunner.Shared;
namespace EndlessRunner.Player
{
    public class PlayerFuelManager : MonoBehaviour
    {
        private int currentFuel;
        private float timer;
        private IPlayerService playerService;
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

        private void Start()
        {           
            currentFuel = GameConstants.MAX_FUEL;
            timer = currentFuel;
        }

        private void Update()
        {
            if (isGameRunning)
            {
                timer -= Time.deltaTime * GameConstants.FUEL_DECREASE_MULTIPLIER;

                if (Mathf.FloorToInt(timer) < currentFuel)
                {
                    currentFuel--;
                    if (playerService == null)
                    {
                        Debug.LogError("PlayerFuelManager : Player Service us null");
                    }
                    playerService.UpdateFuel(currentFuel);
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

        public void AddFuel(int value)
        {
            var result = currentFuel+ value;
            if(result > GameConstants.MAX_FUEL)
            {
                currentFuel = GameConstants.MAX_FUEL;
            }
            else
            {
                currentFuel = result;
                if (playerService == null)
                {
                    Debug.LogError("PlayerFuelManager : Player Service us null");
                }
                playerService.UpdateFuel(currentFuel);
            }
            timer = currentFuel;
        }
    }
}
