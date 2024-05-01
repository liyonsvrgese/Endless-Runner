using EndlessRunner.Player;
using EndlessRunner.Shared;

namespace EndlessRunner.Targets
{
    public class FuelCanManager : BaseTarget
    {
        public override void OnPlayerHit()
        {
            if (player == null)
            {
                return;
            }

            var fuelManager = player.GetComponent<PlayerFuelManager>();
            if(fuelManager != null)
            {
                fuelManager.AddFuel(GameConstants.FUEL_CAN_VALUE);
            }
            
        }
    }
}
