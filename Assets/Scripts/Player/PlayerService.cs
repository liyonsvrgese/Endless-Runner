using UnityEngine;
using EndlessRunner.Shared;

namespace EndlessRunner
{
    public class PlayerService : BaseMonoSingletonGeneric<PlayerService>
    {
        [SerializeField] private Transform playerTransform;

        public Transform PlayerPos => playerTransform;
    }
}
