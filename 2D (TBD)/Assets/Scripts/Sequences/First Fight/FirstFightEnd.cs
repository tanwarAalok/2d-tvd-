using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFightEnd : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private GameObject cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("function");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("is1");
            if (Enemy.GetComponent<EnemyHealth>().isDead)
            {
                Debug.Log("if2");
                cam.GetComponent<CameraFollow>().enabled = true;
                cam.GetComponent<CameraFollow>().minX = 42.5f;
            }
        }
    }
}
