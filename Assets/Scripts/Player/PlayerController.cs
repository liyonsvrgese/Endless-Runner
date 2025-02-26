using UnityEngine;

namespace EndlessRunner.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float playerTurnSpeed;
        [SerializeField] private float playerSpeed;

        private bool canMove = false;
        private Rigidbody rigidBody;
        private Vector3 forwardVector;
        private IPlayerService playerService;
        private float timer = 0f;
        
        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
            forwardVector = new(0, 0, playerSpeed);
        }
        private void OnEnable()
        {
            playerService = PlayerService.Instance;
            if (playerService == null)
            {
                Debug.LogError("PlayerController: Start- Playerservice is null");
            }
            playerService.OnGameOver += HandleGameOver;
            playerService.OnStartGame += StartGame;
        }
        
        private void Update()
        {
            ManageInput();
            CheckToIncreaseSpeed();
        }

        private void CheckToIncreaseSpeed()
        {
            timer += Time.deltaTime;
            if(timer > PlayerConstants.TIME_BTW_SPEED_INCREASE)
            {
                timer = 0;
                playerSpeed += PlayerConstants.SPEED_INCREASE_RATE;
                forwardVector = new(0, 0, playerSpeed);
            }
        }
        private void StartGame()
        {
            canMove = true;
        }
        private void ManageInput()
        {
            if (canMove)
            {
                //Mobile
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.position.x < Screen.width / 2)
                    {
                        MovePlayerLeft();
                    }
                    else
                    {
                        MovePlayerRight();
                    }
                }

                //Editor
                if (Input.GetKey(KeyCode.A))
                {
                    MovePlayerLeft();
                }
                if (Input.GetKey(KeyCode.D))
                {
                    MovePlayerRight();
                }

            }
        }
        private void FixedUpdate()
        {
            if (canMove)
            {
                rigidBody.velocity = forwardVector;
            }
            else
            {
                rigidBody.velocity = Vector3.zero;
            }
        }
        public void MovePlayerLeft()
        {
            var clampedPos = transform.position;
            clampedPos += playerTurnSpeed * Time.deltaTime * Vector3.left;
            clampedPos.x = Mathf.Clamp(clampedPos.x, PlayerConstants.PLAYER_XPOS_MIN, PlayerConstants.PLAYER_XPOS_MAX);
            transform.position = clampedPos;
        }

        public void MovePlayerRight()
        {
            var clampedPos = transform.position;
            clampedPos += playerTurnSpeed * Time.deltaTime * Vector3.right;
            clampedPos.x = Mathf.Clamp(clampedPos.x, PlayerConstants.PLAYER_XPOS_MIN, PlayerConstants.PLAYER_XPOS_MAX);
            transform.position = clampedPos;         
        }

        private void OnDisable()
        {
            playerService.OnGameOver -= HandleGameOver;
        }

        private void HandleGameOver()
        {
            canMove = false;
        }
    }
}

