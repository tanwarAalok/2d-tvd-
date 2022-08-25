using System.Collections;
using System.Collections.Generic;
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
        if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.Mouse0))
        {
            animator.Play("player_attack3");
        }

        if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.Mouse0))
        {
            animator.Play("player_attack1");
        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Mouse0))
        {
            animator.Play("player_attack2");
        }

        
    }
}
