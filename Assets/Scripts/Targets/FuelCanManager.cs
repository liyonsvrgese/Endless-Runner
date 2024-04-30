using UnityEngine;

namespace EndlessRunner.Targets
{
    public class FuelCanManager : BaseTarget
    {
        public override void OnPlayerHit()
        {
            Debug.Log("Fuel can Hit");
        }
    }
}
