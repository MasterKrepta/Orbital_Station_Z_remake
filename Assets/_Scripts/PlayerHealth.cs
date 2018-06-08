using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable {

    [SerializeField] float currentHealth;
    [SerializeField] float maxHealth = 10f;
    [SerializeField] bool invincible = false;
    [SerializeField] float resetTime = 2f;

    public void Die() {
        EventManager.CallOnGameOver(); // This should work
        
        //TODO This is not going to work long term
        //this.gameObject.SetActive(false);
        
    }

    public void TakeDamage(float dmg) {
        if (!invincible) {
            invincible = true;
            currentHealth -= dmg;

            if (currentHealth <= 0)
                Die();
            Invoke("ResetInvulnerability", resetTime);
        }
        else {
            return;
        }

    }

    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
	}


    void ResetInvulnerability() {
        invincible = false;
        
    }
	
	
}
