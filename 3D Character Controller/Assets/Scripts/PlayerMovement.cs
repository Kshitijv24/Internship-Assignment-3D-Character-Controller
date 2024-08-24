using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public bool isSprinting;
    [HideInInspector] public bool isGrounded;

    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] float walkSpeed = 4f;
    [SerializeField] float sprintSpeed = 8f;
    [SerializeField] float jumpHeight = 2;
    [SerializeField] float gravity = -4f;

    CharacterController characterController;
    float turnSmoothVelocity;
    float trueSpeed;
    Vector2 velocity;
    Vector3 direction;

    private void Awake() => characterController = GetComponent<CharacterController>();

    private void Start() => trueSpeed = walkSpeed;

    private void Update()
    {
        HandleMovementAndCameraLook();
        HandleSprinting();
        HandleJumping();
    }

    public bool IsMoving => direction.magnitude >= 0.1f;

    private void HandleMovementAndCameraLook()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0, vertical).normalized;

        if (IsMoving)
        {
            float targetAngle =
                Mathf.Atan2(direction.x, direction.z) *
                Mathf.Rad2Deg +
                Camera.main.transform.eulerAngles.y;

            float turnAngle =
                Mathf.SmoothDampAngle(
                    transform.eulerAngles.y,
                    targetAngle,
                    ref turnSmoothVelocity,
                    turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, turnAngle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDirection.normalized * trueSpeed * Time.deltaTime);
        }
    }

    private void HandleSprinting()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            trueSpeed = sprintSpeed;
            isSprinting = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            trueSpeed = walkSpeed;
            isSprinting = false;
        }
    }

    private void HandleJumping()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, 1);

        if (isGrounded && velocity.y < 0)
            velocity.y = -1;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            velocity.y = Mathf.Sqrt((jumpHeight * 10) * -2f * gravity);

        if (velocity.y > -20)
            velocity.y += (gravity * 10) * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }
}
