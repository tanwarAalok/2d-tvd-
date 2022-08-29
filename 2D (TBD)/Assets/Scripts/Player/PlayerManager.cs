using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    HealthBar healthBar;
    public static bool isPlayerDead = false;
    public static bool isTakingHit = false;
    [SerializeField] int currHealth = 100;
    void Start()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.SetMaxHealth(100);
        healthBar.SetHealth(currHealth);
    }

    // Update is called once per frame
    void Update()
    {
        currHealth = Mathf.Clamp(currHealth, 0, 100);
        healthBar.SetHealth(currHealth);

        if(currHealth == 0){
            GetComponent<Animator>().Play("player_death");
            isPlayerDead = true;
            StartCoroutine(Disappear());
            Debug.Log("Change scene");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.CompareTag("enemy attack")){
            Debug.Log(other.gameObject.GetComponent<AttackDamage>().damage);
            currHealth -= other.gameObject.GetComponent<AttackDamage>().damage;
            isTakingHit = true;
            GetComponent<Animator>().SetTrigger("takeHit");
            GetComponent<Animator>().SetInteger("hitIndex", Random.Range(0, 2));
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(0.5f);
        isTakingHit = false;
    }


    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
