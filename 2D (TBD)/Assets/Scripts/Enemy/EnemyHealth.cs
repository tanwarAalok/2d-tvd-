using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

HealthBar healthBar;
    [SerializeField] int currHealth = 100;
    [SerializeField] int maxHealth = 100;
    void Start()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        currHealth = Mathf.Clamp(currHealth, 0, maxHealth);
        healthBar.SetHealth(currHealth);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.CompareTag("playerAttack")){
            Debug.Log(other.gameObject.GetComponent<AttackDamage>().damage);
            currHealth -= other.gameObject.GetComponent<AttackDamage>().damage;
        }
    }
}
