using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 pos;

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        float axis = Input.GetAxis("Horizontal");

        if (axis < 0) GetComponent<SpriteRenderer>().flipX = true;
        else GetComponent<SpriteRenderer>().flipX = false;

        pos.x += axis * speed *Time.deltaTime;
        transform.position = pos;
    }
}
