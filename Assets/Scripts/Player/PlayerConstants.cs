using UnityEngine;

namespace EndlessRunner.Player
{
    public class PlayerConstants : MonoBehaviour
    {
        public const float PLAYER_XPOS_MIN= -1.75f;

        public const float PLAYER_XPOS_MAX = 1.75f;

        public const string PLAYER_TAG = "Player";

        public const float SPEED_INCREASE_RATE = 0.1f;

        public const float TIME_BTW_SPEED_INCREASE =10f;
    }
}