using UnityEngine;

namespace EndlessRunner.Targets
{
    class EnemyCarManager : BaseTarget
    {
        public override void OnPlayerHit()
        {
            Debug.Log("Enemy car hit");
        }
    }
}
