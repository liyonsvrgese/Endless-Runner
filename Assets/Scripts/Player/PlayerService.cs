using UnityEngine;
using EndlessRunner.Shared;

namespace EndlessRunner.Player
{
    public class PlayerService : BaseMonoSingletonGeneric<PlayerService>
    {
        [SerializeField] private GameObject playerPrefab;
        private Transform playerTransform;
        public Transform PlayerPos => playerTransform;

        private void Start()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            playerTransform = Instantiate(playerPrefab, this.transform).transform;
        }
       
    }
}
