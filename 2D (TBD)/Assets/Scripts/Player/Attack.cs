using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator animator;
    public static bool isAttacking = false;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Jump.isJumping && !PlayerManager.isTakingHit){
            if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.Mouse0) && !isAttacking)
            {
                animator.SetBool("isRunning", false);
                animator.SetTrigger("attack");
                isAttacking = true;
                animator.SetInteger("attackIndex", 2);
                StartCoroutine(WaitForAnimation(0.8f));

            }

            if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.Mouse0) && !isAttacking)
            {
                animator.SetBool("isRunning", false);
                animator.SetTrigger("attack");
                isAttacking = true;
                animator.SetInteger("attackIndex", 0);
                StartCoroutine(WaitForAnimation(0.2f));

            }

            if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Mouse0) && !isAttacking)
            {
                animator.SetBool("isRunning", false);
                animator.SetTrigger("attack");
                isAttacking = true;
                animator.SetInteger("attackIndex", 1);
                StartCoroutine(WaitForAnimation(0.5f));
            }
        }

    }

    IEnumerator WaitForAnimation(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isAttacking = false;
    }
}
