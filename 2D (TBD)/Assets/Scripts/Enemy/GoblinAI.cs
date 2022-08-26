using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAI : MonoBehaviour
{

    [SerializeField] private Transform Player;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isAttacking = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(transform.position, Player.position);
        if (!isAttacking)
        {
            if (dist < 2.85f)
            {
                StartCoroutine(Attack());
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.position, 3f * Time.deltaTime);
                animator.SetBool("isRunning", true);
            }
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
    }

    IEnumerator Attack()
    {
        animator.SetTrigger("attack");
        isAttacking = true;
        animator.SetBool("isRunning", false);
        animator.SetInteger("attackIndex", Random.Range(0, 2));
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }

}
