using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAI : MonoBehaviour
{

    [SerializeField] private Transform Player;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!animator.GetBool("isAttacking"))
        transform.position = Vector2.MoveTowards(transform.position, Player.position, 3f * Time.deltaTime);

        float dist = Vector2.Distance(transform.position, Player.position);

        if(rb.velocity != Vector2.zero)
        {
            animator.SetBool("isRunning", true);
        }

        float diff = transform.position.x - Player.position.x;

        if(diff > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(diff < 0)
        {
            spriteRenderer.flipX = false;
        }


        if(dist < 2.85f)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isAttacking", true);
            animator.SetInteger("attackIndex", Random.Range(0, 2));
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }
}
