using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpVelocity = 10f;
    private Rigidbody2D rigidBody;
    private CapsuleCollider2D playerCollider;
    [SerializeField] private LayerMask platformLayerMask;
    private Animator animator;

    public static bool isJumping = false;


    void Start()
    {
        playerCollider = transform.GetComponent<CapsuleCollider2D>();
        rigidBody = transform.GetComponent<Rigidbody2D>();
        animator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.velocity = Vector2.up * jumpVelocity;
            animator.Play("player_jump");

        }

        isJumping = !isGrounded();
    }

    private bool isGrounded()
    {
        RaycastHit2D rayCastHit2d = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, .1f, platformLayerMask);
        return rayCastHit2d.collider != null;
    }
}
