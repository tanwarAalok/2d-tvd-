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
        if(!Jump.isJumping){
            if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.Mouse0) && !isAttacking)
            {
                animator.SetBool("isRunning", false);
                animator.SetTrigger("attack");
                isAttacking = true;
                animator.SetInteger("attackIndex", 2);
                StartCoroutine(WaitForAnimation());

            }

            if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.Mouse0) && !isAttacking)
            {
                animator.SetBool("isRunning", false);
                animator.SetTrigger("attack");
                isAttacking = true;
                animator.SetInteger("attackIndex", 0);
                StartCoroutine(WaitForAnimation());

            }

            if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Mouse0) && !isAttacking)
            {
                animator.SetBool("isRunning", false);
                animator.SetTrigger("attack");
                isAttacking = true;
                animator.SetInteger("attackIndex", 1);
                StartCoroutine(WaitForAnimation());
            }
        }

    }

    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(0.8f);
        isAttacking = false;
    }
}
