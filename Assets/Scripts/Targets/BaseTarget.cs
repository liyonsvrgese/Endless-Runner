using UnityEngine;
using EndlessRunner.Player;

namespace EndlessRunner.Targets
{
    public abstract class BaseTarget : MonoBehaviour
    {
        protected GameObject player;
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
    }
}