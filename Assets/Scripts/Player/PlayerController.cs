using UnityEngine;

namespace EndlessRunner.Player
{
    public class PlayerController : MonoBehaviour
    {
        private bool canMove = true;
        private Rigidbody rigidBody;
        private Vector3 forwardVector = new(0, 0, PlayerConstants.PLAYER_SPEED);

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            ManageInput();
        }


        private void ManageInput()
        {
            if (canMove)
            {

                //Mobile
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Began)
                    {
                        if (touch.position.x < Screen.width / 2)
                        {
                            MovePlayerLeft();
                        }
                        else
                        {
                            MovePlayerRight();
                        }
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
            clampedPos += PlayerConstants.PLAYER_TURN_SPEED * Time.deltaTime * Vector3.left;
            clampedPos.x = Mathf.Clamp(clampedPos.x, PlayerConstants.PLAYER_XPOS_MIN, PlayerConstants.PLAYER_XPOS_MAX);
            transform.position = clampedPos;
        }

        public void MovePlayerRight()
        {
            var clampedPos = transform.position;
            clampedPos += PlayerConstants.PLAYER_TURN_SPEED * Time.deltaTime * Vector3.right;
            clampedPos.x = Mathf.Clamp(clampedPos.x, PlayerConstants.PLAYER_XPOS_MIN, PlayerConstants.PLAYER_XPOS_MAX);
            transform.position = clampedPos;         
        }
    }
}

