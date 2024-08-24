using UnityEngine;

/// <summary>
/// Controls the player's movement, including walking, sprinting, and jumping.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// Indicates whether the player is currently sprinting. This is managed internally and hidden from the Inspector.
    /// </summary>
    [HideInInspector] public bool isSprinting;

    /// <summary>
    /// Indicates whether the player is currently grounded (i.e., touching the ground). This is managed internally and hidden from the Inspector.
    /// </summary>
    [HideInInspector] public bool isGrounded;

    /// <summary>
    /// The time it takes for the player to smoothly turn in the direction they are moving.
    /// </summary>
    [SerializeField] float turnSmoothTime = 0.1f;

    /// <summary>
    /// The speed at which the player moves when walking.
    /// </summary>
    [SerializeField] float walkSpeed = 4f;

    /// <summary>
    /// The speed at which the player moves when sprinting.
    /// </summary>
    [SerializeField] float sprintSpeed = 8f;

    /// <summary>
    /// The height the player can jump.
    /// </summary>
    [SerializeField] float jumpHeight = 2;

    /// <summary>
    /// The gravity applied to the player. Negative value to simulate downward pull.
    /// </summary>
    [SerializeField] float gravity = -4f;

    // References and movement variables
    private CharacterController characterController;
    private float turnSmoothVelocity;
    private float trueSpeed;
    private Vector2 velocity;
    private Vector3 direction;

    /// <summary>
    /// Called when the script instance is being loaded. Retrieves the CharacterController component attached to the player.
    /// </summary>
    private void Awake() => characterController = GetComponent<CharacterController>();

    /// <summary>
    /// Initializes the player's movement speed to walking speed.
    /// </summary>
    private void Start() => trueSpeed = walkSpeed;

    /// <summary>
    /// Called once per frame to handle player movement, sprinting, and jumping.
    /// </summary>
    private void Update()
    {
        HandleMovementAndCameraLook();
        HandleSprinting();
        HandleJumping();
    }

    /// <summary>
    /// Returns whether the player is currently moving.
    /// </summary>
    public bool IsMoving => direction.magnitude >= 0.1f;

    /// <summary>
    /// Handles the player's movement and smooth rotation based on camera direction.
    /// </summary>
    private void HandleMovementAndCameraLook()
    {
        // Get input from the player
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0, vertical).normalized;

        // Check if the player is moving
        if (IsMoving)
        {
            // Calculate the target angle based on the camera's direction
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

            // Smoothly rotate the player to face the direction of movement
            float turnAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, turnAngle, 0f);

            // Move the player in the calculated direction
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDirection.normalized * trueSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Handles the player's sprinting mechanics, adjusting the movement speed when the sprint key is pressed.
    /// </summary>
    private void HandleSprinting()
    {
        // Start sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            trueSpeed = sprintSpeed;
            isSprinting = true;
        }

        // Stop sprinting
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            trueSpeed = walkSpeed;
            isSprinting = false;
        }
    }

    /// <summary>
    /// Handles the player's jumping mechanics, applying gravity and allowing the player to jump when grounded.
    /// </summary>
    private void HandleJumping()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, 1);

        // If grounded and falling, set the vertical velocity to a small value to keep the player grounded
        if (isGrounded && velocity.y < 0)
            velocity.y = -1;

        // Handle jumping when the player presses the jump key
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            velocity.y = Mathf.Sqrt((jumpHeight * 10) * -2f * gravity);

        // Apply gravity over time to the player's vertical velocity
        if (velocity.y > -20)
            velocity.y += (gravity * 10) * Time.deltaTime;

        // Move the player vertically
        characterController.Move(velocity * Time.deltaTime);
    }
}
