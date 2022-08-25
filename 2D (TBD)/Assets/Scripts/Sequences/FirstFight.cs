using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFight : MonoBehaviour
{

    [SerializeField] private GameObject Goblin;
    [SerializeField] private GameObject cam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Goblin.SetActive(true);
        Vector3 camPos = new Vector3(42.5f, 1f, -10f);
        cam.transform.position = Vector3.Lerp(cam.transform.position, camPos, 2f * Time.deltaTime);
        cam.GetComponent<CameraFollow>().enabled = false;
        Debug.Log(other);
    }
}
