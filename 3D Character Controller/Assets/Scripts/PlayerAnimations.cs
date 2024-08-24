using System.Collections;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    PlayerMovement playerMovement;
    Animator animator;
    Health health;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponentInChildren<Animator>();
        health = GetComponent<Health>();
    }

    private void Update()
    {
        HandlePlayerMovementAnimations();
        HandlePlayerJumpAnimatin();
        HandlePlayerDeathAnimation();
    }

    private void HandlePlayerMovementAnimations()
    {
        if (playerMovement.IsMoving)
        {
            if (playerMovement.isSprinting)
                animator.SetFloat("Speed", 2);
            else
                animator.SetFloat("Speed", 1);
        }
        else
            animator.SetFloat("Speed", 0);
    }

    private void HandlePlayerJumpAnimatin() => animator.SetBool("IsGrounded", playerMovement.isGrounded);

    private void HandlePlayerDeathAnimation()
    {
        if (health.IsPlayerDead())
        {
            StartCoroutine(MakePlayerDown());
            playerMovement.enabled = false;
            animator.SetBool("IsDead", true);
        }
    }

    IEnumerator MakePlayerDown()
    {
        yield return new WaitForSeconds(1.8f);
        playerMovement.transform.position = Vector3.down;
    }
}
