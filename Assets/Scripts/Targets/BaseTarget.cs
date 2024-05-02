using UnityEngine;
using EndlessRunner.Player;

namespace EndlessRunner.Targets
{
    public abstract class BaseTarget : MonoBehaviour
    {
        protected GameObject player;

        private IPlayerService playerService;

        private void OnEnable()
        {
            playerService = PlayerService.Instance;
            if (playerService == null)
            {
                Debug.LogError("BaseTarget- Start - Playerservice is null");
            }

            playerService.OnGameOver += HandleGameOver;
        }       

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag(PlayerConstants.PLAYER_TAG))
            {
                player = other.gameObject;
                OnPlayerHit();
                Destroy(this.gameObject);
            }
        }
        public abstract void OnPlayerHit();

        public virtual void HandleGameOver()
        {
            Destroy(this.gameObject);
        }

        private void OnDisable()
        {
            playerService.OnGameOver -= HandleGameOver;
        }
    }

}