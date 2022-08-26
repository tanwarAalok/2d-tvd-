using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    HealthBar healthBar;
    [SerializeField] int currHealth = 100;
    void Start()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.SetMaxHealth(100);
        healthBar.SetHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        currHealth = Mathf.Clamp(currHealth, 0, 100);
        healthBar.SetHealth(currHealth);
    }
}
