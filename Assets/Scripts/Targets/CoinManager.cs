using UnityEngine;
using EndlessRunner.Player;
using EndlessRunner.Shared;

namespace EndlessRunner.Targets
{
    class CoinManager : BaseTarget
    {
        [SerializeField] private float coinRotateSpeed;

        private IPlayerService playerService;

        private void Start()
        {
            playerService = PlayerService.Instance;
        }
        private void Update()
        {
            RotateCoin();
        }

        private void RotateCoin()
        {
            transform.Rotate(0, 1 * coinRotateSpeed * Time.deltaTime, 0);
        }
        public override void OnPlayerHit()
        {
            if (playerService == null)
            {
                playerService = PlayerService.Instance;
            }
            playerService.AddCoin(GameConstants.COIN_VALUE);
        }
    }
}
