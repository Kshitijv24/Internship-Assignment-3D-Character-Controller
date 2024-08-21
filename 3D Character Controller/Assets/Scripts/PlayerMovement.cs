using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] float walkSpeed = 4f;
    [SerializeField] float sprintSpeed = 8f;
    [SerializeField] float jumpHeight = 2;
    [SerializeField] float gravity = -4f;

    CharacterController characterController;
    float turnSmoothVelocity;
    float trueSpeed;
    bool isGrounded;
    Vector2 velocity;

    private void Awake() => characterController = GetComponent<CharacterController>();

    private void Start() => trueSpeed = walkSpeed;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if(direction.magnitude >= 0.1f)
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

        HandleSprinting();
        HandleJumping();
    }

    private void HandleSprinting()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            trueSpeed = sprintSpeed;

        if (Input.GetKeyUp(KeyCode.LeftShift))
            trueSpeed = walkSpeed;
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
