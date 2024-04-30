using UnityEngine;

namespace EndlessRunner.Targets
{
    class CoinManager : BaseTarget
    {
        [SerializeField] private float coinRotateSpeed;
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
            Debug.Log("Coin Hit");
        }
    }
}
