using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform cam;
    private Vector3 pos;

    // Update is called once per frame
    void Update()
    {
        if(!Attack.isAttacking){
            float axis = Input.GetAxis("Horizontal");
            pos = transform.position;

            if (axis < 0) GetComponent<SpriteRenderer>().flipX = true;
            else if(axis > 0) GetComponent<SpriteRenderer>().flipX = false;

            pos.x += axis * speed * Time.deltaTime;
            pos.x = Mathf.Clamp(pos.x, cam.position.x - 8f, cam.position.x + 8f);
            transform.position = pos;

            if (Input.GetAxis("Horizontal") != 0)
            {
                GetComponent<Animator>().SetBool("isRunning", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("isRunning", false);
            }
        }
    }
}
