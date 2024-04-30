using UnityEngine;
using EndlessRunner.Player;

namespace EndlessRunner.Targets
{
    public abstract class BaseTarget : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag(PlayerConstants.PLAYER_TAG))
            {
                OnPlayerHit();
            }
        }
        public abstract void OnPlayerHit();
    }
}