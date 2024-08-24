using System.Collections;
using UnityEngine;

/// <summary>
/// Controls player animations based on player movement, jumping, and health state.
/// </summary>
public class PlayerAnimations : MonoBehaviour
{
    // References to other components
    private PlayerMovement playerMovement;
    private Animator animator;
    private Health health;

    /// <summary>
    /// Initializes component references.
    /// </summary>
    private void Awake()
    {
        // Get required components from the GameObject
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponentInChildren<Animator>();
        health = GetComponent<Health>();
    }

    /// <summary>
    /// Handles player movement, jumping, and death animations.
    /// </summary>
    private void Update()
    {
        HandlePlayerMovementAnimations();
        HandlePlayerJumpAnimation();
        HandlePlayerDeathAnimation();
    }

    /// <summary>
    /// Manages the player movement animations based on the player's movement state.
    /// </summary>
    private void HandlePlayerMovementAnimations()
    {
        // If the player is moving, adjust speed animation parameter
        if (playerMovement.IsMoving)
        {
            if (playerMovement.isSprinting)
                animator.SetFloat("Speed", 2); // Sprinting speed
            else
                animator.SetFloat("Speed", 1); // Walking speed
        }
        else
        {
            animator.SetFloat("Speed", 0); // Idle speed
        }
    }

    /// <summary>
    /// Updates the jump animation based on whether the player is grounded.
    /// </summary>
    private void HandlePlayerJumpAnimation()
    {
        animator.SetBool("IsGrounded", playerMovement.isGrounded);
    }

    /// <summary>
    /// Handles the death animation and disables player movement if the player is dead.
    /// </summary>
    private void HandlePlayerDeathAnimation()
    {
        if (health.IsPlayerDead())
        {
            StartCoroutine(MovePlayerToTheGround());
            playerMovement.enabled = false;
            animator.SetBool("IsDead", true);
        }
    }

    /// <summary>
    /// Moves the player to the ground over a set duration after death.
    /// </summary>
    /// <returns>IEnumerator for coroutine handling player movement to the ground.</returns>
    private IEnumerator MovePlayerToTheGround()
    {
        yield return new WaitForSeconds(1.8f);

        // Move the player down to the ground level
        playerMovement.transform.position =
            new Vector3(
                playerMovement.transform.position.x,
                -1,
                playerMovement.transform.position.z);
    }
}
