using UnityEngine;
using EndlessRunner.Shared;
namespace EndlessRunner.Player
{
    public class PlayerFuelManager : MonoBehaviour
    {
        private int currentFuel;
        private float timer;
        private IPlayerService playerService;

        private void Start()
        {
            playerService = PlayerService.Instance;
            currentFuel = GameConstants.MAX_FUEL;
            timer = currentFuel;
        }

        private void Update()
        {
            timer -= Time.deltaTime * GameConstants.FUEL_DECREASE_MULTIPLIER;

            if(Mathf.FloorToInt(timer) < currentFuel)
            {               
                currentFuel--;
                if(playerService == null)
                {
                    Debug.LogError("PlayerFuelManager : Player Service us null");
                }
                playerService.UpdateFuel(currentFuel);
            }
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
