using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float SmoothSpeed = 5f;
    [SerializeField] private float maxX, minX;
    private Vector3 newPos;

    // Update is called once per frame
    void Update()
    {
        newPos = new Vector3(Mathf.Clamp(Player.position.x, minX, maxX), Player.position.y + 2, -10f);
        transform.position = Vector3.Lerp(transform.position, newPos, SmoothSpeed * Time.deltaTime);
    }
}
