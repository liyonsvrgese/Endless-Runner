using UnityEngine;
using EndlessRunner.Player;

namespace EndlessRunner.Targets
{
    class RoadBlockManager : BaseTarget
    {
        private IPlayerService playerService;

        private void Start()
        {
            playerService = PlayerService.Instance;
        }
        public override void OnPlayerHit()
        {
            if (playerService == null)
            {
                Debug.LogError("EnemyCarManager : Player Service us null");
            }
            playerService.TriggerGameOver();
        }
    }
}
