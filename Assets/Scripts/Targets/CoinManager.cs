using UnityEngine;

namespace EndlessRunner.Targets
{
    class CoinManager : BaseTarget
    {
        public override void OnPlayerHit()
        {
            Debug.Log("Coin Hit");
        }
    }
}
