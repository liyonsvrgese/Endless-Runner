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
                playerService = PlayerService.Instance;
            }
            playerService.TriggerGameOver();
        }
    }
}
