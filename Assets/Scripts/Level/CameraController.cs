using UnityEngine;
using EndlessRunner.Player;

namespace EndlessRunner.Level
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float yOffset;
        [SerializeField] private float zOffset;

        private Transform playerTransform;
        private Vector3 position;
        private float xMaxPos = PlayerConstants.PLAYER_XPOS_MAX * .5f;
        private float xMinPos = PlayerConstants.PLAYER_XPOS_MIN * .5f;

        private void Start()
        {
            var playerService = PlayerService.Instance;
            if(playerService == null)
            {
                Debug.Log("Camera Controller- Start - PlayerService is null");
                return;
            }

            playerTransform = playerService.PlayerTransform;
        }

        private void LateUpdate()
        {
            if(playerTransform == null)
            {
                var playerService = PlayerService.Instance;
                playerTransform = playerService.PlayerTransform;
            }
            position.x = playerTransform.position.x;  
            position.y = playerTransform.position.y + yOffset;
            position.z = playerTransform.position.z - zOffset;

            transform.position = position;
        }
    }
}
