using UnityEngine;

namespace EndlessRunner.Targets
{
    class EnemyCarManager : BaseTarget
    {
        [SerializeField] private float enemyCarSpeed;

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
            Debug.Log("Enemy car hit");
        }
    }
}
