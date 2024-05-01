using UnityEngine;
using EndlessRunner.Player;

namespace EndlessRunner.Targets
{
    class EnemyCarManager : BaseTarget
    {
        [SerializeField] private float enemyCarSpeed;

        private IPlayerService playerService;

        private void Start()
        {
            playerService = PlayerService.Instance;
        }

        private void Update()
        {
            MoveForward();
        }

        private void MoveForward()
        {
            transform.position += enemyCarSpeed * Time.deltaTime * transform.forward;
        }
        public override void OnPlayerHit()
        {
            if(playerService == null)
            {
                playerService = PlayerService.Instance;
            }
            playerService.TriggerGameOver();
        }
    }
}
