using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    public bool isRunning = false;
    private Vector3 pos;

    // Update is called once per frame
    void Update()
    {
        if (!Attack.isAttacking)
        {
            pos = transform.position;
            float axis = Input.GetAxis("Horizontal");

            if (axis < 0) GetComponent<SpriteRenderer>().flipX = true;
            else GetComponent<SpriteRenderer>().flipX = false;

            pos.x += axis * speed * Time.deltaTime;
            transform.position = pos;

            if (axis != 0)
            {
                GetComponent<Animator>().SetBool("isRunning", true);
                isRunning = true;
            }
            else
            {
                GetComponent<Animator>().SetBool("isRunning", false);
                isRunning = false;
            }
        }
    }
}
