using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    HealthBar healthBar;
    [SerializeField] int currHealth = 100;
    [SerializeField] int maxHealth = 100;
    [SerializeField] string AIScript;
    private Animator animator;

    void Start()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(maxHealth);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currHealth = Mathf.Clamp(currHealth, 0, maxHealth);
        healthBar.SetHealth(currHealth);
        if(currHealth < 1)
        {
            animator.SetTrigger("Dead");
            (GetComponent(AIScript) as MonoBehaviour).enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            Destroy(GetComponent<Rigidbody2D>());
            StartCoroutine(Disappear());
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.CompareTag("playerAttack")){
            Debug.Log(other.gameObject.GetComponent<AttackDamage>().damage);
            currHealth -= other.gameObject.GetComponent<AttackDamage>().damage;
        }
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this);
    }
}
