using UnityEngine;

namespace EndlessRunner.Targets
{
    class RoadBlockManager : BaseTarget
    {
        public override void OnPlayerHit()
        {
            Debug.Log("RoadBlock Hit");
        }
    }
}
